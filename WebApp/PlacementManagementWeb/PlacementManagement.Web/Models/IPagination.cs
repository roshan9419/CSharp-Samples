using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.Web.Models
{
    internal interface IPagination
    {
        int Page { get; set; }
        int Limit { get; set; }
    }
}
