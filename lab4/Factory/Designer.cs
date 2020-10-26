using System;
using System.IO;

namespace Factory
{
    public class Designer
    {
        private readonly IShapeFactory _shapeFactory;

        public Designer(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        public PictureDraft CreateDraft(TextReader inputStream)
        {
            var draft = new PictureDraft();
            string line;
            while (!string.IsNullOrWhiteSpace(line = inputStream.ReadLine()))
                try
                {
                    draft.AddShape(_shapeFactory.CreateShape(line));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            return draft;
        }
    }
}