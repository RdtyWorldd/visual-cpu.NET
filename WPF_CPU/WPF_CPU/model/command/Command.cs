using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CPU.model.command
{
     public class Command
     {
          private int id;
          private CommandType type;
          private int[] args;

          public Command(int id, CommandType type, int[] args)
          {
               ID = id;
               this.type = type;
               this.args = args;
          }

          public int ID { 
               get { return id; } 
               set { id = value; }
          }

          public CommandType Type { get => type; }
          public int[] Args { get => args; }

          public enum CommandType
          {
               LD, ST, MV, INIT, ADD, SUM, SUB, MUL, DIV
          }
     }
}
