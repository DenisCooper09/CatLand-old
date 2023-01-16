using CatLand.Systems.ConsoleSystem.Commands;
using CatLand.Systems.ConsoleSystem.Binary;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

namespace CatLand.Systems.ConsoleSystem
{
    public enum BinaryMathematicalOperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    sealed class ConsoleSystem : MonoBehaviour
    {
        private enum CommandProtectionLevel
        {
            NonProtectedCommand,
            ProtectedCommand
        }

        [field: SerializeField]
        public List<Command> Commands { get; private set; }

        [field: SerializeField]
        public List<ProtectedCommand> ProtectedCommands { get; private set; }

        private const string k_UI = "UI";

        [SerializeField, Foldout(k_UI)] private TMP_InputField m_Input;
        [SerializeField, Foldout(k_UI)] private TMP_InputField m_Output;
        [SerializeField, Foldout(k_UI)] private int m_CaretWidth = 20;

        private int _index; 
        private bool _isProtectedCommandActive;
        private BinaryExpression _binaryExpression;

        private void Awake()
        {
            m_Input.caretWidth = m_CaretWidth;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (_isProtectedCommandActive)
                {
                    if (m_Input.text == _binaryExpression.Answer)
                    {
                        ProtectedCommands[_index].CallCSharpEvent();
                        ProtectedCommands[_index].CallCSharpEventIndex(_index);
                        ProtectedCommands[_index].OnCommandCall?.Invoke();
                        ProtectedCommands[_index].OnCommandCallIndex?.Invoke(_index);

                        Write($"\n>>> {m_Input.text}");
                        Write($"\n>>> Access is gained");
                        Write($"\n>>> The command was executed");

                        m_Input.text = string.Empty;
                        _isProtectedCommandActive = false;
                        _index = 0;

                        if (ProtectedCommands[_index].RemoveAfterCall)
                            ProtectedCommands.RemoveAt(_index);

                        return;
                    }

                    Write("\n<color=red>>>> Wrong password</color>");
                    Write("\n<color=red>>>> Access was denied</color>");

                    m_Input.text = string.Empty;
                    _isProtectedCommandActive = false;
                    return;
                }

                switch (GetCommandProtectionLevel())
                {
                    case CommandProtectionLevel.NonProtectedCommand:
                        int a = 0;
                        while (true)
                        {
                            if (Commands[a].CommandSyntax == m_Input.text)
                            {
                                Commands[a].CallCSharpEvent();
                                Commands[a].CallCSharpEventIndex(a);
                                Commands[a].OnCommandCall?.Invoke();
                                Commands[a].OnCommandCallIndex?.Invoke(a);
                                Write($"\n>>> {Commands[a].CommandSyntax}");
                                m_Input.text = string.Empty;
                                return;
                            }

                            if (a >= Commands.Count - 1)
                            {
                                Write($"\n<color=red>>>> Error</color>");
                                m_Input.text = string.Empty;
                                return;
                            }
                            
                            a++;
                        }
                    case CommandProtectionLevel.ProtectedCommand:
                        int b = 0;
                        while (true)
                        {
                            if (ProtectedCommands[b].CommandSyntax == m_Input.text)
                            {
                                if (ProtectedCommands[b].IsBlocked)
                                {
                                    WriteLine(ProtectedCommands[b].MessageIfBlocked);
                                    m_Input.text = string.Empty;
                                    return;
                                }

                                _isProtectedCommandActive = true;
                                _index = b;

                                Write($"\n>>> {m_Input.text}");
                                Write("\n>>> This command is protected");
                                Write("\n>>> To execute the command solve binary expression");

                                _binaryExpression = new(
                                    ProtectedCommands[b].MinMaxNumber.x,
                                    ProtectedCommands[b].MinMaxNumber.y,
                                    ProtectedCommands[b].OperationType);

                                _binaryExpression.Initialize();

                                Write($"\n>>> {_binaryExpression.Number1}" +
                                    $" {_binaryExpression.OperationSymbol}" +
                                    $" {_binaryExpression.Number2} = ?");

                                m_Input.text = string.Empty;
                                return;
                            }

                            if (b >= ProtectedCommands.Count - 1)
                            {
                                Write($"\n<color=red>>>> Error</color>");
                                m_Input.text = string.Empty;
                                return;
                            }
                            
                            b++;
                        }
                }
            }
        }

        private CommandProtectionLevel GetCommandProtectionLevel()
        {
            int i = 0;
            while (true)
            {
                if (Commands[i].CommandSyntax == m_Input.text)
                    return CommandProtectionLevel.NonProtectedCommand;

                if (i >= Commands.Count - 1)
                    return CommandProtectionLevel.ProtectedCommand;
                
                i++;
            }
        }

        public void Clear()
        {
            m_Output.text = string.Empty;
        }

        public void Write(string message)
        {
            m_Output.text += message;
        }

        public void WriteLine(string message)
        {
            m_Output.text += $"\n{message}";
        }
    }
}
