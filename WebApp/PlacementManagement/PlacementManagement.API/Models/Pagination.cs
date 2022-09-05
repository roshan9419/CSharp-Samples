using System.Collections.Generic;

namespace PlacementManagement.API.Models
{
    public class Pagination
    {
        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; } = 1;
        
        /// <summary>
        /// Page limit size
        /// </summary>
        public int Limit { get; set; } = 10;

        /// <summary>
        /// Use this for passing other parameters
        /// </summary>
        public object[] OtherParams { get; set; }
    }
}