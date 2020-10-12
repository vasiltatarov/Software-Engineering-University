namespace Bubble_Sort.Contacts
{
    public interface ISortable
    {
        int[] CreateRandomArray(int countElements);

        int[] CreateRandomArray(int countElements, int from, int to);

        int[] Sort(int[] array);
    }
}
