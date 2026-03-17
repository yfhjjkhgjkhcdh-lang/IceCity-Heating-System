using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
     public interface IHeaterStrategy
    {
        public double CalcuateEffect(double VALUE);
        string GetName();
    }


}
