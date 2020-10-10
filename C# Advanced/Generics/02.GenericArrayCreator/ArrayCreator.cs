namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            var result =  new T[length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = item;
            }

            return result;
        }
    }
}
