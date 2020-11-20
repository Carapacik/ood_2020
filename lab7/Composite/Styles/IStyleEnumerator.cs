using System.Collections.Generic;

namespace Composite.Styles
{
    public interface IStyleEnumerator<T> where T : IStyle
    {
        IList<T> StyleList { get; }
    }
}