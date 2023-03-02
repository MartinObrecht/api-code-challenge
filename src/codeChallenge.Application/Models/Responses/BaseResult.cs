namespace codeChallenge.Application.Models.Responses
{
    public class BaseResult
    {
        public bool Sucess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}