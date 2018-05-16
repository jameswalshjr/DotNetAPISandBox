using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Domain.Dto
{
    public class FunctionStatusUpdate
    {
        public string FunctionName { get; set; }
        public bool EnableFunction { get; set; }
    }
}
