using System;
using System.Collections.Generic;

namespace DocumentEditor.Commands
{
    public class DeleteItemCommand : AbstractCommand, IDisposable
    {
        private readonly IDocumentItem _documentItem;
        private readonly List<IDocumentItem> _documentItems;
        private readonly int _position;

        public DeleteItemCommand(List<IDocumentItem> documentItems, int position)
        {
            if (documentItems.Count <= 0)
                throw new Exception("Wasn't delete an item from an empty list");
            _documentItems = documentItems;
            _documentItem = documentItems[position];
            _position = position;
        }

        public void Dispose()
        {
            if (IsExecuted)
                _documentItem.Delete();
        }

        protected override void DoExecute()
        {
            _documentItems.RemoveAt(_position);
        }

        protected override void DoUnExecute()
        {
            _documentItems.Insert(_position, _documentItem);
        }
    }
}