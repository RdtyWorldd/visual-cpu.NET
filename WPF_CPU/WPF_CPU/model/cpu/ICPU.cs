using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CPU.model.command;

namespace WPF_CPU.model.cpu
{
     public interface ICPU
     {
          void Execute(Command command);
     }
}
