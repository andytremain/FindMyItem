namespace FindMyItem.Common
{
    public class WebServiceResults
    {
        public class BaseResult
        {
            public bool Succeeded { get; set; }
            public string SuccessMessage { get; set; }
            public string ErrorMessage { get; set; }
        }

        public class JSONReturnValue : WebServiceResults
        {
            public string Test { get; set; }
        }
    }
}