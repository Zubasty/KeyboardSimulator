using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Road _road;

    private int _numberTarget = 0;
    private int _countLose = 0;
    private bool _isWin = false;

    public event Action<Block> SetedTarget;
    public event Action Won;
    public event Action<int> AddedLose;
    public event Action StartedGame;

    public int NumberTarget => _numberTarget;

    public Block Target => _road.GetBlock(_numberTarget);

    public bool IsWin => _isWin;

    public int CountLose => _countLose;

    private void Start()
    {
        TryBlockToWait(Target);
    }

    private void Update()
    {
        if (_isWin) return;

        // Обрабатываем каждый символ, введённый за кадр
        foreach (char typedChar in Input.inputString)
        {
            if (typedChar == '\b') // Убираем бэкспейсы
            {
                continue;
            }

            char checkChar;

            if (typedChar == '\r' || typedChar == '\u2028' || typedChar == '\u2029')
            {
                checkChar = '\n';
            }
            else
            {
                checkChar = typedChar;
            }

            char expectedChar = _road.GetSymbol(_numberTarget);
            if (checkChar == expectedChar)
            {
                // Правильно!
                BlockSymbol block = Target as BlockSymbol;
                block?.Use();

                if (_numberTarget == 0)
                    StartedGame?.Invoke();

                _numberTarget++;

                if (_numberTarget + 1 < _road.CountBlocks)
                {
                    SetedTarget?.Invoke(Target);
                    TryBlockToWait(Target);
                }
                else
                {
                    _isWin = true;
                    Won?.Invoke();
                }
            }
            else
            {
                // Ошибка
                BlockSymbol block = Target as BlockSymbol;
                block?.Fall();
                _countLose++;
                AddedLose?.Invoke(_countLose);
            }
        }
    }

    private bool TryBlockToWait(Block block)
    {
        BlockSymbol blockSymbol = block as BlockSymbol;

        if (blockSymbol)
        {
            blockSymbol.Wait();
            return true;
        }

        return false;
    }
}
