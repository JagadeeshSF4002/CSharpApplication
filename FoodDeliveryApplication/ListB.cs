using System;
namespace FoodDeliveryApplication
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
    }
}