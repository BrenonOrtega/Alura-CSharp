namespace Outbox.Pattern.Application
{
    public class Response
    {
        public string Reason { get; private set; }
        public bool IsSuccess { get; private set; }

        public static Response Success() => new Response(true, string.Empty);
        public static Response Fail(string reason) => new Response(true, reason);

        protected Response(bool isSuccess, string reason)
        {
            IsSuccess = isSuccess;
            Reason = reason;
        }
    }

    public class Response<T> : Response
    {
        public T Value { get; private set; }

        public static Response<T> Success(T value) => new Response<T>(value, true, string.Empty);
        public static new Response<T> Fail(string reason) => new Response<T>(default(T), true, reason);

        private Response(T value, bool isSuccess, string reason) : base(isSuccess, reason)
        {
            Value = value;
        }
    }
}