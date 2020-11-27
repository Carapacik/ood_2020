using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MultiGumBallMachine
{
    public class Menu
    {
        private readonly List<Item> _items;
        private readonly TextReader _textReader;
        private readonly TextWriter _textWriter;
        private bool _exit;

        public Menu(TextWriter textWriter, TextReader textReader)
        {
            _textWriter = textWriter;
            _textReader = textReader;
            _items = new List<Item>();
        }

        public void AddItem(string shortcut, string description, Action<string[]> command)
        {
            _items.Add(new Item(shortcut, description, command));
        }

        public void Run()
        {
            while (!_exit)
            {
                var command = _textReader.ReadLine();
                if (command == null) break;
                try
                {
                    ExecuteCommand(command);
                }
                catch (Exception e)
                {
                    _textWriter.WriteLine(e.Message);
                }
            }
        }

        public void ShowInstructions()
        {
            _textWriter.WriteLine("Commands list");
            foreach (var command in _items) _textWriter.WriteLine($"\t[{command.Shortcut}]:  {command.Description}");
        }

        public void Exit()
        {
            _exit = true;
        }

        private void ExecuteCommand(string command)
        {
            var commandArrData = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!commandArrData.Any())
            {
                _textWriter.WriteLine("Unknown command");
            }
            else
            {
                var item = _items.Where(i => i.Shortcut.ToLower() == commandArrData[0].ToLower());
                if (!item.Any())
                    _textWriter.WriteLine("Unknown command");
                else
                    item.First().Command(commandArrData);
            }
        }
    }
}