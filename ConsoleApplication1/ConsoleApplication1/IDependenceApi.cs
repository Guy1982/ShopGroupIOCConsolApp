using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IDependenceApi
    {
        string SomeApi();
    }
    
    public class DependenceApi : IDependenceApi
    {
        public string SomeApi()
        {
            return "DependenceApi->SomeApi";
        }
    }

}
