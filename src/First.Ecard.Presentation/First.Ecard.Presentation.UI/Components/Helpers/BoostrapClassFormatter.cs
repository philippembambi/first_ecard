using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Helpers
{
    public class BoostrapClassFormatter
    {
        public static string FormatAccountStatus(string status)
        {
            switch (status.ToLower())
            {
                case "active":
                    return "badge badge-sm bg-gradient-success";
                case "inactive":
                case "suspended":
                    return "badge badge-sm bg-gradient-warning";
                case "closed":
                    return "badge badge-sm bg-gradient-danger";
                default:
                    return "badge badge-sm bg-gradient-light";
            }
        }
    }
}