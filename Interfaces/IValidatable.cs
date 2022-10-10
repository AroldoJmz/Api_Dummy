using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Dummy.Interfaces
{
    public interface IValidatable
    {
        List<string> Validation();
    }
}
