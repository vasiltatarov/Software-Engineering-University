namespace Merge_Sort
{
    public class MergeSort
    {
        public void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                var m = (l + r) / 2;

                this.Sort(arr, l, m);
                this.Sort(arr, m + 1, r);

                this.Merge(arr, l, m, r);
            }
        }

        public void Merge(int[] arr, int l, int m, int r)
        {
            var firstSubArrSize = m - l + 1;
            var secondSubArrSize = r - m;

            var leftSide = new int[firstSubArrSize];
            var rightSide = new int[secondSubArrSize];

            CopyDataToLeftSideTemp(arr, l, firstSubArrSize, leftSide);
            CopyDataToRightSideTemp(arr, m, secondSubArrSize, rightSide);

            int i = 0, j = 0;
            var k = l;

            while (i < firstSubArrSize && j < secondSubArrSize)
            {
                if (leftSide[i] <= rightSide[j])
                {
                    arr[k] = leftSide[i];
                    i++;
                }
                else
                {
                    arr[k] = rightSide[j];
                    j++;
                }

                k++;
            }

            while (i < firstSubArrSize)
            {
                arr[k] = leftSide[i];
                i++;
                k++;
            }

            while (j < secondSubArrSize)
            {
                arr[k] = rightSide[j];
                j++;
                k++;
            }
        }

        private static void CopyDataToRightSideTemp(int[] arr, int m, int n2, int[] rightSide)
        {
            for (int i = 0; i < n2; i++)
            {
                rightSide[i] = arr[m + 1 + i];
            }
        }

        private static void CopyDataToLeftSideTemp(int[] arr, int l, int n1, int[] leftSide)
        {
            for (int i = 0; i < n1; i++)
            {
                leftSide[i] = arr[l + i];
            }
        }
    }
}