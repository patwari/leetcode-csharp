namespace L1290;

/// <summary>
/// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/description/?envType=daily-question&envId=2025-07-14
/// 
/// Given head which is a reference node to a singly-linked list. The value of each node in the linked list is either 0 or 1. The linked list holds the binary representation of a number.
/// Return the decimal value of the number in the linked list.
/// The most significant bit is at the head of the linked list.
/// 
/// Approach: O(n)
/// </summary>
public class Solution {
    public int GetDecimalValue(ListNode head) {
        int result = 0;
        ListNode temp = head;

        while (temp != null) {
            if (temp.val == 0) {
                result = (result << 1);
            } else {
                result = (result << 1) ^ 1;
            }

            temp = temp.next;
        }

        return result;
    }
}