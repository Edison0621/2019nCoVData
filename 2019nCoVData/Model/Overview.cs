using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2019nCoVData
{
    public class Overview
    {
        public int Confirm { get; set; }

        public int Suspect { get; set; }

        public int Dead { get; set; }

        public int Heal { get; set; }
    }
}
