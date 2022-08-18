using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    abstract class GenericAbstract<T1, T2>
    {
        public abstract (T2, T1) SwapValues(T1 valueA, T2 valueB);
        public T1 GetWorking(T1 featureId)
        {
            return featureId;
        }
    }

    class GenericAbstractChild<T1, T2> : GenericAbstract<T1, T2>
    {
        public override (T2, T1) SwapValues(T1 valueA, T2 valueB)
        {
            return (valueB, valueA);
        }
    }
}
