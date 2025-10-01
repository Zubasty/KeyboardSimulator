using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly string SpeedKey = "Speed";
    private readonly string WinKey = "Win";

    [SerializeField] private CameraAnimation _cameraAnimaton;

    private Animator _animator;
    private Mover _mover;
    private Player _player;
    private float _speed = 0;

    public event Action EndedWaiting;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _mover.Moved += OnMoved;
        _player.Won += OnWon;
    }

    private void OnDisable()
    {
        _mover.Moved -= OnMoved;
        _player.Won -= OnWon;
    }

    private void OnMoved(float speed)
    {
        _speed = speed;
        _animator.SetFloat(SpeedKey, _speed);
    }

    private void OnWon()
    {
        StartCoroutine(WaitForStopAndAnimate());
    }

    private IEnumerator WaitForStopAndAnimate()
    {
        // Ждём, пока моделька полностью остановится
        while (_mover.IsMoving)
        {
            yield return null;
        }

        // Анимация камеры к игроку
        yield return StartCoroutine(_cameraAnimaton.MoveToPlayer(_player));

        // Запускаем анимацию победы
        _animator.SetTrigger(WinKey);
        EndedWaiting?.Invoke();
    }
}