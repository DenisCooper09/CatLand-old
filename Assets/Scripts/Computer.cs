using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Computer : MonoBehaviour
{
    public static event Action OnCorrectAnswer, OnWrongAnswer, OnAllQuestionsCorrectAnswer;

    private enum MathOperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    [SerializeField] private bool m_UseRandom = false;

    private const string MathematicalExpressionHeader = "Mathematical Expressions Settings";

    [SerializeField, BoxGroup(MathematicalExpressionHeader), HideIf(nameof(m_UseRandom))]
    private MathOperationType m_MathOperationType = MathOperationType.Addition;

    [SerializeField, BoxGroup(MathematicalExpressionHeader), Range(3, 15)] private int m_MathematicalExpressionsCount = 3;
    [SerializeField, BoxGroup(MathematicalExpressionHeader), MinMaxSlider(0, 100)] private Vector2Int m_MinMaxNumber;

    private const string UI = nameof(UI);

    [SerializeField, Foldout(UI)] private TextMeshProUGUI m_MathematicalExpressionText;
    [SerializeField, Foldout(UI)] private TextMeshProUGUI m_MathematicalExpressionNumberText;
    [SerializeField, Foldout(UI)] private TMP_InputField m_AnswerInputField;

    private const string Caret = nameof(Caret);

    [Header(Caret)]
    [SerializeField, Foldout(UI)] private float m_CaretBlinkRate = 3f;
    [SerializeField, Foldout(UI)] private int m_CaretWidth = 25;

    private int _currentMathematicalExpressionNumber;
    private MathematicalExpression[] _mathematicalExpressions;
    private bool _correct = false;

    private void Awake()
    {
        _mathematicalExpressions = MakeMathematicalExpressions();
        UpdateMathematicalExpressionUI();
        m_AnswerInputField.caretBlinkRate = m_CaretBlinkRate;
        m_AnswerInputField.caretWidth = m_CaretWidth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (m_AnswerInputField.text == "/restart")
            {
                m_MathematicalExpressionText.color = Color.green;
                m_AnswerInputField.text = string.Empty;
                _mathematicalExpressions = MakeMathematicalExpressions();
                UpdateMathematicalExpressionUI();
                return;
            }

            if (m_AnswerInputField.text == _mathematicalExpressions[_currentMathematicalExpressionNumber].Answer)
            {
                OnCorrectAnswer?.Invoke();

                if (_currentMathematicalExpressionNumber + 1 == m_MathematicalExpressionsCount)
                {
                    OnAllQuestionsCorrectAnswer?.Invoke();
                    _currentMathematicalExpressionNumber = 0;
                    PrintMessage("Correct!", Color.green);
                    m_AnswerInputField.text = string.Empty;
                    _correct = true;
                    return;
                }

                _currentMathematicalExpressionNumber++;
                m_AnswerInputField.text = string.Empty;
                UpdateMathematicalExpressionUI();
            }
            else if (m_AnswerInputField.text != _mathematicalExpressions[_currentMathematicalExpressionNumber].Answer)
            {
                OnWrongAnswer?.Invoke();
                _currentMathematicalExpressionNumber = 0;
                PrintMessage("Wrong!", Color.red);
                m_AnswerInputField.text = string.Empty;
            }
        }
    }

    public void MakeNewMathematicalExpressionsOnExit()
    {
        if (!_correct) return;
        _mathematicalExpressions = MakeMathematicalExpressions();
        UpdateMathematicalExpressionUI();
        m_AnswerInputField.text = string.Empty;
        _correct = false;
    }

    private void PrintMessage(string message, Color color)
    {
        m_MathematicalExpressionText.color = color;
        m_MathematicalExpressionText.text = message;
    }

    private MathematicalExpression[] MakeMathematicalExpressions()
    {
        MathematicalExpression[] mathematicalExpressions = new MathematicalExpression[m_MathematicalExpressionsCount];

        for (int i = 0; i < m_MathematicalExpressionsCount; i++)
        {
            MathOperationType mathOperationType = m_UseRandom == true ? GetRandomMathOperationType() : m_MathOperationType;
            int number1;
            int number2;

            if (mathOperationType == MathOperationType.Division)
            {
                do
                {
                    number2 = GetRandomNumber(m_MinMaxNumber.x);
                    number1 = GetRandomNumber(number2);
                }
                while ((number1 % 2) != 0 && (number2 % 2) != 0);
            }

            number2 = GetRandomNumber(m_MinMaxNumber.x);
            number1 = GetRandomNumber(number2);

            mathematicalExpressions[i] = new MathematicalExpression(number1, number2, mathOperationType);
        }

        return mathematicalExpressions;
    }

    private int GetRandomNumber(int min)
    {
        return Random.Range(min, m_MinMaxNumber.y);
    }

    private MathOperationType GetRandomMathOperationType()
    {
        Type type = typeof(MathOperationType);
        Array values = type.GetEnumValues();
        return (MathOperationType)values.GetValue(Random.Range(0, values.Length));
    }

    private sealed class MathematicalExpression
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

            MathOperationType = mathOperationType;
        }

        public string Number1 { get; private set; }
        public string Number2 { get; private set; }
        public string Answer { get; private set; }
        public MathOperationType MathOperationType { get; private set; }
    }

    private static string ConvertToBinary(int number)
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

    private void UpdateMathematicalExpressionUI()
    {
        m_MathematicalExpressionNumberText.text =
            $"{_currentMathematicalExpressionNumber + 1} of {m_MathematicalExpressionsCount}";
        m_MathematicalExpressionText.text =
            $"{_mathematicalExpressions[_currentMathematicalExpressionNumber].Number1} " +
            $"{GetOperationSymbol()} " +
            $"{_mathematicalExpressions[_currentMathematicalExpressionNumber].Number2} = ?";
    }

    private string GetOperationSymbol()
    {
        return _mathematicalExpressions[_currentMathematicalExpressionNumber].MathOperationType switch
        {
            MathOperationType.Addition => "+",
            MathOperationType.Subtraction => "-",
            MathOperationType.Multiplication => "*",
            MathOperationType.Division => "/",
            _ => throw new Exception("Unsupported type of math operation."),
        };
    }
}
