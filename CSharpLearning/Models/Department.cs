using System;
using System.Collections.Generic;

namespace CSharpLearning.DSL
{
    public class Department
    {
        public string Name { get; set;}
        public int Id { get; set;}
        public int Type { get; set; }
        public int State { get; set; }
        public IEnumerable<Unit> Units { get; set; }

        public Department()
        {
        }
    }
}