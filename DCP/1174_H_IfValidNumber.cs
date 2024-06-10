namespace D1174;

/// <summary>
/// This problem was asked by LinkedIn.
/// Given a string, return whether it represents a number. Here are the different kinds of numbers:
///     "10", a positive integer
///     "-10", a negative integer
///     "10.1", a positive real number
///     "-10.1", a negative real number
///     "1e5", a number in scientific notation
/// And here are examples of non-numbers:
///     "a"
///     "x 1"
///     "a -2"
///     "-"
/// Approach: Traversal
/// </summary>
public class Solution {
    public bool IsValidNum(string str) {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        int n = str.Length;
        return IsValidPositiveInt(str, 0, n - 1)
            || IsValidNegativeInt(str, 0, n - 1)
            || IsValidPositiveReal(str, 0, n - 1)
            || IsValidNegativeReal(str, 0, n - 1)
            || IsValidScientific(str, 0, n - 1);
    }

    private bool IsValidPositiveInt(string str, int s, int e) {
        if (e < s)
            return false;
        for (int i = s; i <= e; ++i)
            if (str[i] < '0' || str[i] > '9')
                return false;
        return true;
    }

    private bool IsValidNegativeInt(string str, int s, int e) {
        if (str[s] != '-')
            return false;
        return IsValidPositiveInt(str, s + 1, e);
    }

    private bool IsValidPositiveReal(string str, int s, int e) {
        bool dotFound = false;
        int i = s;
        while (i <= e) {
            if (str[i] == '.') {
                if (dotFound)
                    return false;
                dotFound = true;
                break;
            }
            ++i;
        }

        if (!dotFound)
            return false;
        return IsValidPositiveInt(str, s, i - 1) && IsValidPositiveInt(str, i + 1, e);
    }

    private bool IsValidNegativeReal(string str, int s, int e) {
        if (str[s] != '-')
            return false;
        return IsValidPositiveReal(str, s + 1, e);
    }

    /// <summary>
    /// Allowed: In scientific notation: 
    ///     {real}-e-{int}
    /// </summary>
    private bool IsValidScientific(string str, int s, int e) {
        bool eFound = false;
        int i = s;
        while (i <= e) {
            if (str[i] == 'e' || str[i] == 'E') {
                if (eFound)
                    return false;
                eFound = true;
                break;
            }
            ++i;
        }
        if (!eFound)
            return false;
        return (IsValidPositiveReal(str, s, i - 1) || IsValidNegativeReal(str, s, i - 1) || IsValidPositiveInt(str, s, i - 1) || IsValidNegativeInt(str, s, i - 1)) && (IsValidPositiveInt(str, i + 1, e) || IsValidNegativeReal(str, i + 1, e));
    }
}