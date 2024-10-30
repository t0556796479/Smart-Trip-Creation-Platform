using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class GoogleMapsApiResponse
    {
        public string Status { get; set; }
        public Row[] Rows { get; set; }
    }

    public class Row
    {
        public Element[] Elements { get; set; }
    }

    public class Element
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
    }

    public class Distance
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

    public class Duration
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

}
