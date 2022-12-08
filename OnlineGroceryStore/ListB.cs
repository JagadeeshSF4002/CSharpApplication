using System;
namespace OnlineGroceryStore
{
   public partial class List<Type>
    {
        public void AddRange(List<Type> dataList)
        {
            _capacity = _count + dataList.Count + 4;
            Type[] temp = new Type[_capacity];

            for(i=0 ; i< _count;i++)
            {
                temp[i] = _array[i];
            }
            int j=0;

            for(i = _count;i < _count+dataList.Count;i++)
            {
                temp[i] = dataList[j] ;
                j++;
            }
            _array = temp;
            _count+=dataList.Count;
        }

        public void Remove(Type data)
        {
            _capacity = _capacity + 1;
            Type[] temp = new Type[_capacity];
            int k = 0;
            for(var i = 0 ; i < _count-1;i++)
            {
                if(_array[i].Equals(data))
                {
                    temp[i] = _array[i+1];
                    k = i+2;   
                }
                else
                {
                     temp[i] = _array[k];
                     k++;          
                }
            }
            _array = temp;
            _count--;
        }

       

        public bool Contains(Type data)
        {
            for(int i=0;i<_count;i++)
            {
                if(_array[i].Equals(data))
                {
                    return true;
                }
            }
            return false;
        }
    }
}