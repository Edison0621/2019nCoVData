using System;
using System.Collections.Generic;
using System.Text;

namespace _2019nCoVData
{
    public class AreaTree
    {
        public AreaTree()
        {
            this.Today = new Today();
            this.Total = new Overview();
            this.Children = new List<Children>();
        }
        public string Name { get; set; }

        public Today Today { get; set; }

        public Overview Total { get; set; }

        public List<Children> Children { get; set; }
    }

    public class Children
    {
        public string Name { get; set; }

        public Today Today { get; set; }

        public Overview Total { get; set; }
    }
}
