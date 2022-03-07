using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Player _player;

    private bool _isTicking = false;
    private TimeSpan _time = TimeSpan.Zero;

    public event Action<TimeSpan> SetedTime;

    public TimeSpan Time => _time;

    private void OnEnable()
    {
        _player.StartedGame += OnStartedGame;
        _player.Won += () => _isTicking = false;
    }

    private void OnDisable()
    {
        _player.StartedGame -= OnStartedGame;
        _player.Won -= () => _isTicking = false;
    }

    private void Update()
    {
        if (_isTicking)
        {
            _time = _time.Add(new TimeSpan(0,0,0,0,Mathf.RoundToInt(1000 * UnityEngine.Time.deltaTime)));
            SetedTime?.Invoke(_time);
        }
    }

    private void OnStartedGame()
    {
        _isTicking = true;
    }
}
