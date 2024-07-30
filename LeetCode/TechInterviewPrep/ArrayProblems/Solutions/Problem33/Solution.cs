namespace ArrayProblems.Solutions.Problem33;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return nums[0] == target ? 0 : -1;
        }

        if (nums[0] < nums[n - 1])
        {
            return BinarySearch(nums, 0, n - 1, target);
        }

        var pivot = FindPivotIndex(nums);

        if (pivot == -1)
        {
            return -1;
        }

        return target >= nums[0]
            ? BinarySearch(nums, 0, pivot, target)
            : BinarySearch(nums, pivot + 1, n - 1, target);
    }

    private static int FindPivotIndex(int[] arr)
    {
        var left = 0;
        var right = arr.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (arr[mid] > arr[mid + 1])
            {
                return mid;
            }

            if (arr[mid] > arr[right])
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
        }

        return -1;
    }

    private static int BinarySearch(int[] arr, int left, int right, int target)
    {
        while (left < right - 1)
        {
            var mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }

            if (arr[mid] > target)
            {
                right = mid;
            }
            else
            {
                left = mid;
            }
        }

        return arr[left] == target
            ? left
            : arr[right] == target
                ? right
                : -1;
    }
}