using AliaaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TciCommon.Models
{
    [CollectionSave(WriteLog = false, UnifyChars = false)]
    public class ExceptionLog : MongoEntity
    {
        private const int INNER_EXCEPTION_COUNT = 50;

        public ExceptionLog() { }

        public ExceptionLog(Exception Exception, string Url)
        {
            this.Url = Url;
            Message = Exception.Message;
            StackTrace = Exception.StackTrace;
            if (Exception.InnerException != null)
            {
                List<Exception> hierarchyList = new List<Exception>();
                hierarchyList.Add(Exception);
                Exception current = Exception.InnerException;
                while (current != null && !hierarchyList.Contains(current) && InnerExceptions.Count < 50)
                {
                    InnerExceptions.Add(Tuple.Create(current, current.Message, current.StackTrace));
                    hierarchyList.Add(current);
                    current = current.InnerException;
                }
            }
        }
        
        public Exception Exception { get; private set; }
        public string Url { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public List<Tuple<Exception, string, string>> InnerExceptions { get; set; } = new List<Tuple<Exception, string, string>>();
    }
}