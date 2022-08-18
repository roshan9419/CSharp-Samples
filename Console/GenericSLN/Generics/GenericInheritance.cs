using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class GenericGrandParent<T>
    {
        internal virtual string WhoIAm()
        {
            return "GrandParent";
        }
    }

    internal class GenericParent<T1, T2>: GenericGrandParent<T1>
    {
        internal override string WhoIAm()
        {
            return "Parent";
        }
    }

    internal class GenericChild<E>: GenericParent<E, int> // hardcoding primitive datatype, or else take another type F
    {
        internal new string WhoIAm()
        {
            return "Child";
        }
    }
}
