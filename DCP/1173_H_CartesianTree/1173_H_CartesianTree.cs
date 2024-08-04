using Utils;

namespace D1173;

/// <summary>
/// This problem was asked by Netflix.
/// A Cartesian tree with sequence S is a binary tree defined by the following two properties:
///     It is heap-ordered, so that each parent value is strictly less than that of its children.
///     An in-order traversal of the tree produces nodes with values that correspond exactly to S.
/// For example, given the sequence[3, 2, 6, 1, 9], the resulting Cartesian tree would be:
///       1
///     /   \   
///   2       9
///  / \
/// 3   6
/// Given a sequence S, construct the corresponding Cartesian tree.
/// <br/><br/>
/// 
/// Approach: Recursion.
/// In given range, find minimum. 
/// Set it as root.
/// Create children.
/// </summary>
public class Solution {
    public TreeNode? ConstructCartesian(int[] nums) {
        if (nums == null || nums.Length == 0) return null;
        var a = Aux(nums, 0, nums.Length - 1);
        return a;
    }

    private TreeNode? Aux(int[] nums, int s, int e) {
        if (s > e) return null;
        if (s == e) return new TreeNode(nums[s]);

        // find min in range
        int minIdx = s;
        for (int i = s + 1; i <= e; ++i) {
            if (nums[i] < nums[minIdx])
                minIdx = i;
        }

        return new TreeNode(nums[minIdx], Aux(nums, s, minIdx - 1), Aux(nums, minIdx + 1, e));
    }
}