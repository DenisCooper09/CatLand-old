using System;

namespace CatLand.Systems.ConsoleSystem.Binary
{
    sealed class BinaryExpression
    {
        public string Number1 { get; private set; }
        public string Number2 { get; private set; }
        public string Answer { get; private set; }
        public char OperationSymbol { get; private set; }

        private readonly int _min;
        private readonly int _max;
        private readonly BinaryMathematicalOperationType _operationType;

        public BinaryExpression(int min, int max, BinaryMathematicalOperationType operationType)
        {
            _min = min;
            _max = max;
            _operationType = operationType;
        }

        public void Initialize()
        {
            int[] numbers = GenerateRandomNumbers(_min, _max, _operationType);

            Number1 = ConvertToBinary(numbers[0]);
            Number2 = ConvertToBinary(numbers[1]);

            Answer = _operationType switch
            {
                BinaryMathematicalOperationType.Addition => ConvertToBinary(numbers[0] + numbers[1]),
                BinaryMathematicalOperationType.Subtraction => ConvertToBinary(numbers[0] - numbers[1]),
                BinaryMathematicalOperationType.Multiplication => ConvertToBinary(numbers[0] * numbers[1]),
                BinaryMathematicalOperationType.Division => ConvertToBinary(numbers[0] / numbers[1]),
                _ => throw new Exception("Unsupported type of math operation."),
            };

            OperationSymbol = _operationType switch
            {
                BinaryMathematicalOperationType.Addition => '+',
                BinaryMathematicalOperationType.Subtraction => '-',
                BinaryMathematicalOperationType.Multiplication => '*',
                BinaryMathematicalOperationType.Division => '/',
                _ => throw new Exception("Unsupported type of math operation."),
            };
        }

        private int[] GenerateRandomNumbers(int min, int max, BinaryMathematicalOperationType operationType)
        {
            int number1;
            int number2;

            if (operationType == BinaryMathematicalOperationType.Division)
            {
                do
                {
                    number2 = GetRandomNumber(min, max);
                    number1 = GetRandomNumber(number2, max);
                }
                while ((number1 % 2) != 0 && (number2 % 2) != 0);
            }

            number2 = GetRandomNumber(min, max);
            number1 = GetRandomNumber(number2, max);

            return new int[] { number1, number2 };
        }

        private int GetRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }

        private string ConvertToBinary(int number)
        {
            const int k_mask = 1;
            string binary = default;

            while (number > 0)
            {
                binary = (number & k_mask) + binary;
                number >>= 1;
            }

            return binary;
        }
    }
}
