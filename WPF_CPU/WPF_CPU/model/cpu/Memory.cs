using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CPU.model.cpu
{
     public class Memory
     {
          private int[] register;
          private int[] memory;

          public Memory(int[] register, int[] memory)
          {
               this.register = register;
               this.memory = memory;
          }

          public int[] Registers { get { return register; } }
          public int[] Mem { get { return memory; } }
     }
}
