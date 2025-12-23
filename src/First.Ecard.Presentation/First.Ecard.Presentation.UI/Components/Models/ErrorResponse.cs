using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class ErrorResponse
    {
        public string Message {get; set;} = string.Empty;
        public string[] Errors {get; set;} = [];
    }
}