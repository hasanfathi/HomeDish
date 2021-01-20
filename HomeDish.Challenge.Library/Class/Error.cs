using System;

namespace HomeDish.Challenge.Library.Class
{
    public class Error
    {
        public Error()
        {
            this.Message = "No Error";
            this.Code = 0;
        }
        public Error(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }
        public Error(string message, int code, DateTime time)
        {
            this.Message = message;
            this.Code = code;
            this._time = time;
        }

        private DateTime _time { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public string time => _time == DateTime.MinValue ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                         : _time.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
