namespace Factory
{
    public class Painter
    {
        public void DrawPicture(PictureDraft draft, ICanvas canvas)
        {
            for (var i = 0; i < draft.ShapeCount; i++)
            {
                var shape = draft.GetShape(i);
                shape.Draw(canvas);
            }
        }
    }
}