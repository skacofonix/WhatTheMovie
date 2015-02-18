using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class Range : IRange
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
