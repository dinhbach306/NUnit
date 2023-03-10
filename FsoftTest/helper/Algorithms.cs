using DataAccess;

namespace FsoftTest.helper;

public static class Algorithms
{
    public static int RemoveDuplicates(int[] nums)
    {
        int i = 1;
        foreach(var n in nums)
            if(n > nums[i - 1])
                nums[i++] = n;
        
        return i;
    }
    
    public static string LargestNumber(int[] nums) 
    {
        if(nums.All(x => x == 0)) return "0";

        var s = nums.Select(x => x.ToString()).ToList();

        s.Sort((a, b) => (b+a).CompareTo(a+b));

        return string.Concat(s);
    }
    
    
    public static int[] Sort(int[] list) {
        for (int i = 0; i < list.Length -1; i++) {
            for(int j = i + 1; j < list.Length; j++) {
                int tmp;
                if (list[i] < list[j]) {
                    tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;
                }
            }
        }
        return list;
    }
    
    public static List<Product> SortSelection(List<Product> list) {
        for (int i = 0; i < list.Count -1; i++) {
            for(int j = i + 1; j < list.Count; j++) {
                Product tmp;
                if (list[i].UnitPrice < list[j].UnitPrice) {
                    tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;
                }
            }
        }
        return list;
    }

    public static int Fibonacci(int i)
    {
        if (i == 0)
        {
            return 0;
        } else if(i == 1) {
            return 1;
        } else return (Fibonacci(i - 1) + Fibonacci(i - 2));
    }
}