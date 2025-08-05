using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CPU.model.command;
namespace WPF_CPU.model
{
    public class ProgrammModel : IEnumerable<Command>
    {
        private List<Command> commands = new List<Command>();

        public delegate void ProgrammDelegate();
        public event ProgrammDelegate ProgrammChange;

        public int GetCommandCount() { return commands.Count; }
        public void Add(Command command)
        {
            commands.Add(command);
            ProgrammChange();
        }

        public Command Get(int id)
        {
            return commands[id];
        }

        public void Delete(int id)
        {
            commands.RemoveAt(id);
            ProgrammChange();
        }

        public void Delete(Command command)
        {
            commands.Remove(command);
            ProgrammChange();
        }

        public void Reset()
        {
            commands.Clear();
            ProgrammChange();
        }

        public void UpCommand(int id)
        {
            if (id <= 0) return; //throw 
            Command tmp = commands[id];
            commands[id] = commands[id - 1];
            commands[id - 1] = tmp;
        }

        public void DownCommand(int id)
        {
            if (id >= commands.Count) return; //throw 
            Command tmp = commands[id];
            commands[id] = commands[id + 1];
            commands[id + 1] = tmp;
        }

        public IEnumerator<Command> GetEnumerator()
        {
            return commands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)commands).GetEnumerator();
        }
    }
}
