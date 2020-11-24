namespace DocumentEditor.Commands
{
    public class SetTitleCommand : AbstractCommand
    {
        private readonly Text _document;
        private string _title;

        public SetTitleCommand(Text document, string title)
        {
            _document = document;
            _title = title;
        }

        private void SwapValues()
        {
            var temp = _document.Value;
            _document.Value = _title;
            _title = temp;
        }

        protected override void DoExecute()
        {
            SwapValues();
        }

        protected override void DoUnExecute()
        {
            SwapValues();
        }
    }
}