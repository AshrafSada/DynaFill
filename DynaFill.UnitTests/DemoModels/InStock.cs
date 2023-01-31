using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaFill.UnitTests.DemoModels
{
    public class InStock
    {
        public InStock()
        {
            Cars = new Car[] { };
        }
        public Car[] Cars { get; set; }
    }
}