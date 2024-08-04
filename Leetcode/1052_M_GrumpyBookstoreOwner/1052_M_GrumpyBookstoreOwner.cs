namespace L1052;

/// <summary>
/// https://leetcode.com/problems/grumpy-bookstore-owner/?envType=daily-question&envId=2024-06-21
/// <br/><br/>
///  
/// customers[] <- represents how many customers coming at i-th minute.
/// grumpy[] <- represents if owner is grumpy. 0 = happy. 1 = grumpy.
/// When owner is grumpy, no customer is served.
/// owner, only once, can make himself happy for `minutes` minutes.
/// What is the max count of customers served.
/// <br/><br/>
/// 
/// Approach:
/// If grumpy[i] == 1 => total += customers[i] <= as even without algo running, these customers will be served.
/// Create a new array containing loss of how many unserved customer by minute. loss[i] = customer[i], if grumpy. arr[i] = 0, if happy. NOTE: we're counting unserved.
/// Now we want to maximize total sum in above loss[], by making him happy `minutes` minutes.
/// So, find the max total of subarray size `minutes`. Because if we make owner happy, all loss[i] in that subarray will be added to total. So, we want to maximize the profit.
/// </summary>
public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int total = 0;

        for (int i = 0; i < customers.Length; ++i) {
            if (grumpy[i] == 0)
                total += customers[i];
        }

        int windowSum = 0;
        // Set the first window sum
        for (int right = 0; right < minutes; ++right) {
            windowSum += grumpy[right] == 1 ? customers[right] : 0;
        }

        int maxx = windowSum;
        // now find the window of size minutes, which has max window sum.
        for (int left = 1; left < grumpy.Length - minutes + 1; ++left) {
            int right = left + minutes - 1;
            windowSum += grumpy[right] == 1 ? customers[right] : 0;
            windowSum -= grumpy[left - 1] == 1 ? customers[left - 1] : 0;
            maxx = Math.Max(maxx, windowSum);
        }

        return maxx + total;
    }
}