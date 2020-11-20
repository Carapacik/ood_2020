namespace Composite.Styles
{
    public class OutlineGroupStyle : GroupStyle<IOutlineStyle>, IOutlineStyle
    {
        public OutlineGroupStyle(IStyleEnumerator<IOutlineStyle> styleEnumerator) : base(styleEnumerator)
        {
        }
    }

    public class GroupStyle<T> : IStyle where T : class, IStyle
    {
        private readonly IStyleEnumerator<T> _styleEnumerator;

        public GroupStyle(IStyleEnumerator<T> styleEnumerator)
        {
            _styleEnumerator = styleEnumerator;
        }

        public uint? Thickness
        {
            get
            {
                if (!(_styleEnumerator is IStyleEnumerator<IOutlineStyle> outLineEnumerator))
                    return null;

                var firstVal = outLineEnumerator.StyleList[0].Thickness;
                for (var i = 1; i < outLineEnumerator.StyleList.Count; i++)
                {
                    var curVal = outLineEnumerator.StyleList[i].Thickness;
                    if (curVal == null || curVal != firstVal) return null;
                }

                return firstVal;
            }
            set
            {
                if (!(_styleEnumerator is IStyleEnumerator<IOutlineStyle> outLineEnumerator))
                    return;

                foreach (var t in outLineEnumerator.StyleList) t.Thickness = value;
            }
        }

        public bool? IsEnabled
        {
            get
            {
                var firstVal = _styleEnumerator.StyleList[0].IsEnabled;
                for (var i = 1; i < _styleEnumerator.StyleList.Count; i++)
                {
                    var curVal = _styleEnumerator.StyleList[i].IsEnabled;
                    if (curVal == null || curVal != firstVal) return null;
                }

                return firstVal;
            }
            set
            {
                foreach (var t in _styleEnumerator.StyleList) t.IsEnabled = value;
            }
        }

        public uint? Color
        {
            get
            {
                var firstVal = _styleEnumerator.StyleList[0].Color;
                for (var i = 1; i < _styleEnumerator.StyleList.Count; i++)
                {
                    var curVal = _styleEnumerator.StyleList[i].Color;
                    if (curVal == null || curVal != firstVal) return null;
                }

                return firstVal;
            }
            set
            {
                foreach (var t in _styleEnumerator.StyleList) t.Color = value;
            }
        }
    }
}