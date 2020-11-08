namespace DocumentEditor.Commands
{
    public class SetTitleCommand : AbstractCommand
    {
        private readonly IDocument _document;
        private string _title;

        public SetTitleCommand(IDocument document, string title)
        {
            _document = document;
            _title = title;
        }

        private void SwapValues()
        {
            var temp = _document.Title;
            _document.Title = _title;
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