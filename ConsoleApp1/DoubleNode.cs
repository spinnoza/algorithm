using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DoubleNode
    {
        public int Value { get; set; }

        public DoubleNode Last { get; set; }
        public DoubleNode Next { get; set; }

        public DoubleNode(int data)
        {
            Value = data;
        }

    }
}
