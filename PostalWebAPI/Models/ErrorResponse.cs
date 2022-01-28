using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.Models
{
    public enum Errors
    {
        ExceptionOccured
    }

    public class ErrorResponse
    {
        public string SessionID { get; set; } = string.Empty;
        public bool Error { get; set; }
        public Errors Reason { get; set; }
    }
}
