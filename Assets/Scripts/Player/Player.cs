using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Database _database;
    [SerializeField] private Road _road;

    private int _numberTarget = 0;
    private int _countLose = 0;
    private bool _isWin = false;

    public event Action<Block> SetedTarget;
    public event Action Won;
    public event Action<int> AddedLose;
    public event Action StartedGame;

    public Block Target => _road.GetBlock(_numberTarget);

    public bool IsWin => _isWin;

    public int CountLose => _countLose;

    private void Start()
    {
        BlockSymbol block = Target as BlockSymbol;
        if (block)
            block.Wait();
    }

    private void Update()
    {
        if (IsWin == false && Input.anyKeyDown)
        {
            if(FindButtonDown(out KeyCode keyCode))
            {
                WorkWithRoad(keyCode);
            }
        }
    }

    private bool FindButtonDown(out KeyCode key)
    {
        foreach (KeyCode keyCode in _database.Keys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                key = keyCode;
                return true;
            }
        }
        key = KeyCode.None;
        return false;
    }

    private void WorkWithRoad(KeyCode keyCode)
    {
        BlockSymbol block = Target as BlockSymbol;

        if (_database.HaveKeySymbol(keyCode, _road.GetSymbol(_numberTarget)))
        {
            if (block)
            {
                block.Use();
            }

            if (_numberTarget == 0)
            {
                StartedGame?.Invoke();
            }

            _numberTarget++;

            if (_numberTarget < _road.CountBlocks)
            {
                SetedTarget?.Invoke(Target);

                if (_numberTarget == _road.CountBlocks - 1)
                {
                    _isWin = true;
                    Won?.Invoke();
                }
                else
                {
                    block = Target as BlockSymbol;

                    if (block)
                        block.Wait();
                }
            }
        }
        else
        {
            block.Fall();
            _countLose++;
            AddedLose?.Invoke(_countLose);
        }
    }
}
