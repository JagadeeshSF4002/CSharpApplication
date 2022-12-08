using System;
using System.Collections;

namespace CollegeAdmissionWithFile
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
            Reset();//Reset Position value if no element in list
            return false;
        }

        public void Reset()
        {
            i = -1;
        }


        public object Current //Return the current array position value
        {
            get {return _array[i];}
        }


    }
}