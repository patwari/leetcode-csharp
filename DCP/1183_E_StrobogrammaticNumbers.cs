namespace D1183;

/// <summary>
/// This problem was asked by Twitter.
/// A strobogrammatic number is a positive number that appears the same after being rotated 180 degrees. For example, 16891 is strobogrammatic.
/// Create a program that finds all strobogrammatic numbers with N digits.
/// <br/><br/>
/// 
/// Approach: Recursive
/// Only digits = 0,1,8 are the same in 180-degree. 6 and 9 are 180-degree same of each other.
/// </summary>
public class Solution {
    public List<string> StrobogrammaticNumbers(int N) {
        List<string> items = new();
        char[] item = new char[N];
        Aux(N, items, item, 0, N - 1);
        return items;
    }

    /// <param name="left">now put at this place</param>
    /// <param name="right">now put at this place</param>
    private void Aux(int N, List<string> items, char[] item, int left, int right) {
        if (left > right) {
            items.Add(string.Join("", item));
            return;
        }

        if (left == right) {
            item[left] = '0';
            Aux(N, items, item, left + 1, right - 1);
            item[left] = '1';
            Aux(N, items, item, left + 1, right - 1);
            item[left] = '8';
            Aux(N, items, item, left + 1, right - 1);
            return;
        }

        // we cannot use 0 at start or end
        if (left != 0) {
            item[left] = '0';
            item[right] = '0';
            Aux(N, items, item, left + 1, right - 1);
        }

        item[left] = '1';
        item[right] = '1';
        Aux(N, items, item, left + 1, right - 1);

        item[left] = '8';
        item[right] = '8';
        Aux(N, items, item, left + 1, right - 1);

        item[left] = '6';
        item[right] = '9';
        Aux(N, items, item, left + 1, right - 1);

        item[left] = '9';
        item[right] = '6';
        Aux(N, items, item, left + 1, right - 1);
    }
}