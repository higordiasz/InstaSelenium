using System;

namespace InstagramNavegador.Models.Results
{
    public class Result
    {
        public int Status { get; set; }
        public string Response { get; set; }
        public dynamic Json { get; set; }
        public Exception Err { get; set; }
        public string PageContent { get; set; }

        public Result(int status, string response)
        {
            this.Status = status;
            this.Response = response;
            this.Json = null;
            this.PageContent = "";
            this.Err = null;
        }
    }
}
