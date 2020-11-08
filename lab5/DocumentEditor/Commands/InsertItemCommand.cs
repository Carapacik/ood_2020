using System;
using System.Collections.Generic;

namespace DocumentEditor.Commands
{
    public class InsertItemCommand : AbstractCommand
    {
        private readonly List<IDocumentItem> _allItems;
        private readonly IDocumentItem _item;
        private readonly int _position;

        public InsertItemCommand(List<IDocumentItem> allItems, IDocumentItem item, int position)
        {
            _allItems = allItems;
            _item = item;
            _position = position == -1 ? Math.Max(_allItems.Count, 0) : position;
        }

        protected override void DoExecute()
        {
            _allItems.Insert(_position, _item);
        }

        protected override void DoUnExecute()
        {
            _allItems.RemoveAt(_position);
        }
    }
}