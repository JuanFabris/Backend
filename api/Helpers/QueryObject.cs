using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        //Filter
        public string? Name { get; set; } = null;
        public string? Username { get; set; } = null;
        
        //Sort
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        
        //Show amount of Players per Page
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}