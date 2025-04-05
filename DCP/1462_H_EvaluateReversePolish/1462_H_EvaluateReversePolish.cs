namespace D1462;

/// <summary>
/// This problem was asked by Jane Street.
/// Given an arithmetic expression in Reverse Polish Notation, write a program to evaluate it.
/// The expressions is always valid.
/// Approach: Stack. O(n)
/// </summary>
public class Solution {
    public float Evaluate(string expression) {
        Stack<float> operands = new();
        string[] parts = expression.Split(",");

        foreach (string p in parts) {
            string pp = p.Trim();
            switch (pp) {
                case "+":
                    operands.Push(DoOperation(operands, Operator.PLUS));
                    break;
                case "-":
                    operands.Push(DoOperation(operands, Operator.MINUS));
                    break;
                case "*":
                    operands.Push(DoOperation(operands, Operator.MULTIPLY));
                    break;
                case "/":
                    operands.Push(DoOperation(operands, Operator.DIVIDE));
                    break;
                default:
                    operands.Push(float.Parse(pp));
                    break;
            }
            Console.Write("");
        }

        return operands.Pop();
    }

    private float DoOperation(Stack<float> operands, Operator op) {
        float b = operands.Pop();
        float a = operands.Pop();
        switch (op) {
            case Operator.PLUS: return a + b;
            case Operator.MINUS: return a - b;
            case Operator.MULTIPLY: return a * b;
            case Operator.DIVIDE: return a / b;
            default: throw new Exception($"Invalid operator :: {op}");
        }
    }

    private enum Operator {
        PLUS,
        MINUS,
        MULTIPLY,
        DIVIDE
    }
}