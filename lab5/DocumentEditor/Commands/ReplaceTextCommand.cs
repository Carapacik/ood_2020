namespace DocumentEditor.Commands
{
    public class ReplaceTextCommand : AbstractCommand
    {
        private readonly IParagraph _paragraph;
        private string _text;

        public ReplaceTextCommand(IParagraph paragraph, string text)
        {
            _paragraph = paragraph;
            _text = text;
        }

        private void SwapValues()
        {
            var temp = _paragraph.Text;
            _paragraph.Text = _text;
            _text = temp;
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