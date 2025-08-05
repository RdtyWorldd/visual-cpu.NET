using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CPU.model.command;

namespace WPF_CPU.model.cpu
{
    public class LittleCpu : ICPU
    {
        private Memory mem;
        public LittleCpu(Memory mem)
        {
            if (mem.Registers.Length < 4)
            {
                throw new ArgumentException();
            }
            this.mem = mem;
        }
        public void Execute(Command command)
        {
            switch (command.Type)
            {
                case Command.CommandType.LD: ld(command); break;
                case Command.CommandType.ST: st(command); break;
                case Command.CommandType.MV: mv(command); break;
                case Command.CommandType.ADD: add(); break;
                case Command.CommandType.SUB: sub(); break;
                case Command.CommandType.MUL: mult(); break;
                case Command.CommandType.DIV: div(); break;
                default: break;
            }
        }

        private void ld(Command command)
        {
            mem.Registers[command.Args[0]] = mem.Mem[command.Args[1]];
        }
        private void st(Command command)
        {
            mem.Mem[command.Args[0]] = mem.Registers[command.Args[1]];
        }
        private void mv(Command command)
        {
            mem.Registers[command.Args[0]] = mem.Registers[command.Args[1]];
        }
        private void add()
        {
            mem.Registers[3] = mem.Registers[0] + mem.Registers[1];
        }
        private void sub()
        {
            mem.Registers[3] = mem.Registers[0] - mem.Registers[1];
        }
        private void mult()
        {
            mem.Registers[3] = mem.Registers[0] * mem.Registers[1];
        }
        private void div()
        {
            mem.Registers[3] = mem.Registers[0] / mem.Registers[1];
        }
    }
}
