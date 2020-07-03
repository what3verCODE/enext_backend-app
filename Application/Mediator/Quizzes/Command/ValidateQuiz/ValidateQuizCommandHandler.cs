using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Application.Mediator.Quizzes.Command.ValidateQuiz
{
    public class ValidateQuizCommandHandler : IRequestHandler<ValidateQuizCommand, QuizValidationResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        
        public ValidateQuizCommandHandler(ApiDataContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<QuizValidationResponse> Handle(ValidateQuizCommand request, CancellationToken cancellationToken)
        {
            var lessonId = (await _context.Quizzes
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Include(x => x.Section)
                .FirstOrDefaultAsync(cancellationToken)).Section.LessonId;
            
            var quiz = await _context.Quizzes
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Include(x => x.Questions)
                .ThenInclude(y => y.Answers)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(quiz == null)
                throw new System.NotImplementedException();

            var response = new QuizValidationResponse();

            foreach (var question in quiz.Questions)
            {
                response.MaxAttempts = quiz.MaxAttempts;
                response.Questions ??= new List<QuizValidationResponse.QuestionValidationResponse>();

                var responseAnswers = 
                    question.Answers.Select(answer => 
                        new QuizValidationResponse.AnswerValidationResponse()
                        {
                            Id = answer.Id, 
                            Value = answer.Value, 
                            Wrong = request.Questions.Any(x 
                                => x.Answers.Any(y 
                                    => y.Id == answer.Id && y.IsSelected != answer.IsCorrect)), 
                            IsSelected = request.Questions.Any(x
                                => x.Answers.Any(y 
                                    => y.Id == answer.Id && y.IsSelected))
                        }).ToList();

                response.Questions.Add(new QuizValidationResponse.QuestionValidationResponse()
                {
                    Id = question.Id,
                    Type = question.Type,
                    Value = question.Value,
                    Score = question.Score,
                    Answers = new List<QuizValidationResponse.AnswerValidationResponse>(responseAnswers),
                });
            }
            
            var progress = await _context.Progresses
                .AsNoTracking()
                .Where(x => x.LessonId == lessonId && x.UserId == _currentUser.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (response.Questions.All(x => x.Answers.All(y => y.Wrong == false)))
            {
                progress.Score = response.Questions.Sum(x => x.Score);
                _context.Progresses.Update(progress);
            }

            var attempt = await _context.UserQuizAttempts
                .AsNoTracking()
                .Where(x => x.UserId == _currentUser.UserId && x.QuizId == quiz.Id && x.ProgressId == progress.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (attempt == null)
            {
                attempt = new QuizAttempts
                {
                    AttemptId = 1,
                    ProgressId = progress.Id,
                    QuizId = quiz.Id,
                    UserId = _currentUser.UserId,
                    Result = JsonConvert.SerializeObject(response) // TODO: JSON STRINGIFY
                };
                response.MaxAttempts--;
                await _context.UserQuizAttempts.AddAsync(attempt, cancellationToken);
            }
            else
            {
                var count = _context.UserQuizAttempts.Count(x =>
                    x.UserId == _currentUser.UserId && x.QuizId == quiz.Id && x.ProgressId == progress.Id);

                if(count == quiz.MaxAttempts)
                    throw new NotImplementedException();
                
                if (count < quiz.MaxAttempts)
                {
                    attempt = new QuizAttempts
                    {
                        AttemptId = count + 1,
                        ProgressId = progress.Id,
                        QuizId = quiz.Id,
                        UserId = _currentUser.UserId,
                        Result = JsonConvert.SerializeObject(response) // TODO: JSON STRINGIFY
                    };
                    await _context.UserQuizAttempts.AddAsync(attempt, cancellationToken);
                    response.MaxAttempts -= count + 1;
                }
                else
                {
                    response.MaxAttempts = 0;
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            
            return response;
        }
    }
}