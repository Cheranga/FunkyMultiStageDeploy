namespace FunkyDeploy.Services.Core
{
    public class Result
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }

        public static Result Success()
        {
            return new Result
            {
                Status = true
            };
        }

        public static Result Failure(string errorMessage)
        {
            return new Result
            {
                Status = false,
                ErrorMessage = errorMessage
            };
        }
    }

    public class Result<TData>
    {
        public TData Data { get; set; }
        public string ErrorMessage { get; set; }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>
            {
                Data = data
            };
        }

        public static Result<TData> Failure(string errorMessage)
        {
            return new Result<TData>
            {
                ErrorMessage = errorMessage
            };
        }
    }
}