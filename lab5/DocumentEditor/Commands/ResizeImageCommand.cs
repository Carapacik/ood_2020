namespace DocumentEditor.Commands
{
    public class ResizeImageCommand : AbstractCommand
    {
        private readonly IImage _image;
        private int _height;
        private int _width;

        public ResizeImageCommand(IImage image, int width, int height)
        {
            _image = image;
            _width = width;
            _height = height;
        }

        private void SwapValues()
        {
            var tempWidth = _image.Width;
            var tempHeight = _image.Height;
            _image.Resize(_width, _height);
            _width = tempWidth;
            _height = tempHeight;
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