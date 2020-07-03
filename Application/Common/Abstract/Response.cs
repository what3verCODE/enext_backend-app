namespace Application.Common.Abstract
{
    public abstract class Response<T>
    {
        public T Data { get; set; }
        public ResponseStatus Status { get; set; }
    }
}