using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using WPF_CPU.model.cpu;

namespace WPF_CPU.model
{
    public class ExecutorModel
    {
        private Memory mem;
        private ICPU cpu;

        private bool debug = false;
        private bool run = false;
        private int position = 0;

        public delegate void ExecuteDelegate();
        public event ExecuteDelegate Exec;

        public ExecutorModel()
        {
            mem = new Memory(new int[4], new int[512]);
            cpu = new LittleCpu(mem);
        }

        public void Execute(ProgrammModel programm)
        {
            if (debug)
            {
                position = 0;
                run = true;
            }
            else 
            {
                foreach(var cmnd in programm) 
                    cpu.Execute(cmnd);
            }
            Exec();
        }

        public void DebugNext(ProgrammModel programm)
        {
            cpu.Execute(programm.Get(position));
            position++;
            if (position == programm.GetCommandCount())
            {
                run = false;
            }
            Exec();
        }

    }
}
