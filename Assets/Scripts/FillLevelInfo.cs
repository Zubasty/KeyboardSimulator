using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FillLevelInfo : MonoBehaviour
{
    [SerializeField] private Player _player;
    private TextMeshProUGUI _info;

    private void Awake()
    {
        _info = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.SetedTarget += OnSetedTarget;
        _player.Won += OnWon;
    }

    private void Start()
    {
        _info.text = "0/" + (TypeTextSwitcher.TEXT_FOR_GAME.Length).ToString();
    }

    private void OnDisable()
    {
        _player.SetedTarget -= OnSetedTarget;
        _player.Won -= OnWon;
    }

    private void OnSetedTarget(Block block)
    {
        _info.text = _player.NumberTarget.ToString() + "/" + (TypeTextSwitcher.TEXT_FOR_GAME.Length).ToString();
    }
    private void OnWon()
    {
        _info.text = (TypeTextSwitcher.TEXT_FOR_GAME.Length).ToString() + "/" + (TypeTextSwitcher.TEXT_FOR_GAME.Length).ToString();
    }
}
