using System;
using System.Collections.Generic;

namespace DocumentEditor.Commands
{
    public class History : IHistory
    {
        private const int Capacity = 10;
        private readonly List<ICommand> _commands = new List<ICommand>();
        private int _nextCommandIndex;
        public bool CanRedo => _nextCommandIndex < _commands.Count;
        public bool CanUndo => _nextCommandIndex > 0;

        public void AddAndExecuteCommand(ICommand command)
        {
            if (_commands.Count >= Capacity)
            {
                _commands.RemoveAt(0);
                _nextCommandIndex--;
            }

            if (_nextCommandIndex < _commands.Count)
                _commands.RemoveRange(_nextCommandIndex, _commands.Count - _nextCommandIndex);

            _commands.Add(command);
            Redo();
        }

        public void Undo()
        {
            if (!CanUndo)
                throw new Exception("Cannot undo because there are no commands before this!");
            _commands[--_nextCommandIndex].UnExecute();
        }

        public void Redo()
        {
            if (CanRedo)
                _commands[_nextCommandIndex++].Execute();
            else
                throw new Exception("Cannot redo because there are no commands after this!");
        }
    }
}