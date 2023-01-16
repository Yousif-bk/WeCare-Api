namespace WeCare_Api.Modals
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        //public List<ValidationError> ValidationErrors { get; set; }
        public BaseResponse()
        {

        }
        public BaseResponse(bool success, int statusCode, string responseMessage, int totalRecord)
        {
            IsSuccess = success;
            StatusCode = statusCode;
            ResponseMessage = responseMessage;
        }
        public BaseResponse(bool success, int statusCode, string responseMessage, List<ValidationError> validationErrors = null)
        {
            IsSuccess = success;
            StatusCode = statusCode;
            ResponseMessage = responseMessage;
            //ValidationErrors = validationErrors;
        }
    }

    public class ValidationError
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}


           
