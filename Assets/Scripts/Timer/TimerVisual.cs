using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimerVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.SetedTime += OnSetedTime;
    }

    private void OnDisable()
    {
        _timer.SetedTime -= OnSetedTime;
    }

    private void OnSetedTime(TimeSpan timeSpan)
    {
        _text.text = $"{timeSpan.Hours}:{timeSpan.Minutes.ToString("00")}:{timeSpan.Seconds.ToString("00")}";
    }
}
