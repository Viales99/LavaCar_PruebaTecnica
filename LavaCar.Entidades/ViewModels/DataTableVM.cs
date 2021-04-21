using System;
using System.Collections.Generic;
using System.Text;

namespace LavaCar.Entidades.ViewModels
{
    public class DataTableVM
    {
        public string Draw { get; set; }
        public string Start { get; set; }
        public string Length { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
        public string SearchValue { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int RecordsTotal { get; set; }
    }
}
