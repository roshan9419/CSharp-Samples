using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class GenericCollection<T>
    {
        List<T> _list;

        public GenericCollection()
        {
            _list = new List<T>();
        }
        public GenericCollection(int length)
        {
            _list = new List<T>(length);
        }

        internal void PushItem(T value)
        {
            _list.Add(value);
        }

        internal int SearchItem(T value)
        {
            return _list.IndexOf(value);
        }
    }
}
