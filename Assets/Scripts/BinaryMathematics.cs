using System;
using UnityEngine;

public enum MathOperationType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class BinaryMathematics : MonoBehaviour
{
    protected sealed class MathematicalExpression
    {
        public MathematicalExpression(int number1, int number2, MathOperationType mathOperationType)
        {
            Number1 = ConvertToBinary(number1);
            Number2 = ConvertToBinary(number2);

            Answer = mathOperationType switch
            {
                MathOperationType.Addition => ConvertToBinary(number1 + number2),
                MathOperationType.Subtraction => ConvertToBinary(number1 - number2),
                MathOperationType.Multiplication => ConvertToBinary(number1 * number2),
                MathOperationType.Division => ConvertToBinary(number1 / number2),
                _ => throw new Exception("Unsupported type of math operation."),
            };

            OperationSymbol = mathOperationType switch
            {
                MathOperationType.Addition => '+',
                MathOperationType.Subtraction => '-',
                MathOperationType.Multiplication => '*',
                MathOperationType.Division => '/',
                _ => throw new Exception("Unsupported type of math operation."),
            };

            MathOperationType = mathOperationType;
        }

        public string Number1 { get; private set; }
        public string Number2 { get; private set; }
        public string Answer { get; private set; }
        public char OperationSymbol { get; private set; }
        public MathOperationType MathOperationType { get; private set; }
    }

    protected static string ConvertToBinary(int number)
    {
        const int mask = 1;
        string binary = default;

        while (number > 0)
        {
            binary = (number & mask) + binary;
            number >>= 1;
        }

        return binary;
    }
}
