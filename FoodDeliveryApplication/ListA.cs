using System;
using System.Collections;

namespace FoodDeliveryApplication
{
    public partial class List<Type> : IEnumerable, IEnumerator
    {
        int i;
        public IEnumerator GetEnumerator()
        {
            i = -1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if(i < _count-1)
            {
                ++i;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            i = -1;
        }


        public object Current 
        {
            get {return _array[i];}
        }


    }
}