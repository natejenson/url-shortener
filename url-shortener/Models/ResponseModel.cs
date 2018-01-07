using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace url_shortener.Models
{
    public class ResponseModel
    {
        int StatusCode { get; set; }
        dynamic Data { get; set; }
        string Message { get; set; }
    }
}
