using System;

namespace HomeDish.Challenge.Library.Class
{
    public class Reply
    {
        public Reply()
        {
            this.Result = string.Empty;
            this.Error = new Error();
        }
        public Reply(object Result)
        {
            this.Result = Result;
            this.Error = new Error();
        }
        public Reply(object Result, Error error)
        {
            this.Result = Result;
            this.Error = error;
        }

        public object Result { get; set; }
        public Error Error { get; set; }
    }
}
