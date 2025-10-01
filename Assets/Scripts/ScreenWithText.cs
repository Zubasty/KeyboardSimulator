using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScreenWithText : MonoBehaviour
{
    private const int COUNT_LINES_ON_SCREEN = 3;

    [SerializeField] private Player _player;

    private TextMeshProUGUI _textMesh;
    private int _numberLine;
    private List<Tuple<int, string>> _textForScreen;

    private void OnSetedTarget(Block block)
    {
        //Debug.Log($"{_player.NumberTarget} {_textForScreen[_numberLine].Item1}");
        if (_player.NumberTarget > _textForScreen[_numberLine].Item1 && _numberLine + COUNT_LINES_ON_SCREEN < _textForScreen.Count)
        {
            _numberLine += 1;
            SetTextOnScreen();
        }
    }

    private void OnWon()
    {
        _textMesh.text = "";
    }

    private void SetTextOnScreen()
    {
        string st = "";
        for (int i = 0; i < Mathf.Min(COUNT_LINES_ON_SCREEN, _textForScreen.Count); i++)
        {
            st += _textForScreen[_numberLine + i].Item2;
            if (i < COUNT_LINES_ON_SCREEN - 1)
                st += "\n";
        }
        _textMesh.text = st;
    }

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.SetedTarget += OnSetedTarget;
        _player.Won += OnWon;
    }

    private void OnDisable()
    {
        _player.SetedTarget -= OnSetedTarget;
        _player.Won -= OnWon;
    }

    private void Start()
    {
        _numberLine = 0;
        _textForScreen = TextUtils.GetScreenText(TypeTextSwitcher.TEXT_FOR_GAME);
        SetTextOnScreen();
    }
}
