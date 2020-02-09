using System;
using System.Collections.Generic;
using System.Text;

namespace _2019nCoVData
{
    public class ChinaDay : Overview
    {
        public decimal DeadRate { get; set; }

        public decimal HealRate { get; set; }

        public string Date { get; set; }
    }
}
