namespace codeChallenge.Application.Models.Responses
{
    public class BaseResult<T>
    {
        public bool Sucess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}