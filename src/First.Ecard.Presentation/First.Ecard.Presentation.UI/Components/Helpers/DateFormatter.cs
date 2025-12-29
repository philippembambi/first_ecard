using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Helpers
{
    public class DateFormatter
    {
        public static string GetDateFromDateTime(string date)
        {
            return date.Substring(0, 10);
        }
    }
}