using System;

namespace Application.Common.Exceptions
{
    public class CourseStatusException : Exception
    {
        public CourseStatusException(string name, object key)
            : base($"{name} with id {key} is published or await for publishing. For editing course should be in development mode.")
        { }
    }
}