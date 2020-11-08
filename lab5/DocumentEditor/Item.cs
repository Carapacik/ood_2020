using System;

namespace DocumentEditor
{
    public class Item
    {
        public Item(string shortcut, string description, Action<string[]> command)
        {
            Shortcut = shortcut;
            Description = description;
            Command = command;
        }

        public string Shortcut { get; }
        public string Description { get; }
        public Action<string[]> Command { get; }
    }
}