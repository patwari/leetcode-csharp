namespace L1106;

public class Solution {
    /// <summary>
    /// A boolean expression is an expression that evaluates to either true or false. It can be in one of the following shapes: <br/>
    /// 't' that evaluates to true. <br/>
    /// 'f' that evaluates to false. <br/>
    /// '!(subExpr)' that evaluates to the logical NOT of the inner expression subExpr. <br/>
    /// '&amp;(subExpr1, subExpr2, ..., subExprn)' that evaluates to the logical AND of the inner expressions subExpr1, subExpr2, ..., subExprn where n >= 1. <br/>
    /// '|(subExpr1, subExpr2, ..., subExprn)' that evaluates to the logical OR of the inner expressions subExpr1, subExpr2, ..., subExprn where n >= 1. <br/>
    /// Given a string expression that represents a boolean expression, return the evaluation of that expression. <br/>
    /// <br/>
    /// Approach: Stack. O(2 * n) <br/>
    /// - continue to add expressions in a list.
    /// - when a closing bracket is found, evaluate expressions from the corresponding open bracket, ie: in the list.
    /// - Always continue to collapse result.
    /// 
    /// Time Complexity: we check each char. Each expression, once evaluated, is collapsed. And therefore there is no inner loop. 
    /// </summary>

    public bool ParseBoolExpr(string expression) {
        if (expression == "t") return true;
        if (expression == "f") return false;

        int idx = 1;
        if (expression[0] == '!')
            return EvaluateBracket(expression, Operation.NOT, ref idx);
        else if (expression[0] == '&')
            return EvaluateBracket(expression, Operation.AND, ref idx);
        else if (expression[0] == '|')
            return EvaluateBracket(expression, Operation.OR, ref idx);
        else
            throw new Exception($"Invalid expression = {expression}");
    }

    // idx is the index of the opening bracket = '(', right after an operator. And it will evaluate until its matching ')' is found
    private bool EvaluateBracket(string str, Operation op, ref int idx) {
        // skip the open bracket
        ++idx;
        List<bool> results = new List<bool>();

        while (idx < str.Length) {
            if (str[idx] == ',') {
                ++idx;
            } else if (str[idx] == 't') {
                ++idx;
                results.Add(true);
            } else if (str[idx] == 'f') {
                ++idx;
                results.Add(false);
            } else if (str[idx] == '!') {
                ++idx;
                results.Add(EvaluateBracket(str, Operation.NOT, ref idx));
            } else if (str[idx] == '&') {
                ++idx;
                results.Add(EvaluateBracket(str, Operation.AND, ref idx));
            } else if (str[idx] == '|') {
                ++idx;
                results.Add(EvaluateBracket(str, Operation.OR, ref idx));
            } else if (str[idx] == ')') {
                ++idx;
                break;
            } else {
                throw new Exception($"Invalid character found = char = {str[idx]} :: expression = {str}");
            }
        }


        if (op == Operation.NOT) {
            if (results.Count != 1) throw new Exception($"invalid operands for NOT operation. ops = {string.Join(", ", results)}");
            return !results[0];
        }

        if (op == Operation.AND) {
            if (results.Count == 0) throw new Exception($"No operands found for AND operation");
            bool output = true;
            foreach (bool item in results) {
                output &= item;
            }
            return output;
        }

        {
            if (results.Count == 0) throw new Exception($"No operands found for OR operation");
            bool output = false;
            foreach (bool item in results) {
                output |= item;
            }
            return output;
        }
    }

    private enum Operation {
        OR,
        AND,
        NOT
    }
}