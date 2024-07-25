namespace LeetCode.DailyProblems.Solutions.Problem912;

public class Solution
{
    public int[] SortArray(int[] nums)
    {
        QuickSort(nums, 0, nums.Length - 1);

        return nums;
    }

    private void QuickSort(int[] nums, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        var pivotIndex = MedianOfThree(nums, left, right);
        var pivot = Partition(nums, left, right, pivotIndex);

        QuickSort(nums, left, pivot - 1);
        QuickSort(nums, pivot + 1, right);
    }


    private int Partition(int[] nums, int left, int right, int pivotIndex)
    {
        var pivotValue = nums[pivotIndex];
        var storeIndex = left;

        Swap(ref nums[pivotIndex], ref nums[right]); // Move pivot to end

        for (var i = left; i < right; ++i)
        {
            if (nums[i] < pivotValue)
            {
                Swap(ref nums[i], ref nums[storeIndex]);

                ++storeIndex;
            }
        }

        Swap(ref nums[storeIndex], ref nums[right]); // Move pivot to its final place

        return storeIndex;
    }

    private int MedianOfThree(int[] nums, int left, int right)
    {
        int center = left + (right - left) / 2;

        if (nums[left] > nums[center])
        {
            Swap(ref nums[left], ref nums[center]);
        }

        if (nums[left] > nums[right])
        {
            Swap(ref nums[left], ref nums[right]);
        }

        if (nums[center] > nums[right])
        {
            Swap(ref nums[center], ref nums[right]);
        }

        return center;
    }

    private void Swap(ref int num1, ref int num2)
    {
        int temp = num1;
        num1 = num2;
        num2 = temp;
    }
}