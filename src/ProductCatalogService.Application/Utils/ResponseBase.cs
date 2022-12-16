namespace ProductCatalogService.Application.Utils
{
    public class ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsError { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public List<ValidationMessage> Errors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="message"></param>
        public void SetFailureResponse(string property, string message)
        {
            IsError = true;
            Errors = new List<ValidationMessage>
            {
                new ValidationMessage
                {
                    Message = message,
                    Property = property
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        public void SetFailureResponse(List<ValidationMessage> errors)
        {
            IsError = true;
            Errors.AddRange(errors);
        }
        /// <summary>
        ///  Status Code
        /// </summary>
        public int StatusCode { get; set; }
    }
}
