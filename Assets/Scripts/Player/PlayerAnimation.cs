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
    private readonly int NumberLayerAnimator = 0;

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

    private void OnWon()
    {
        StartCoroutine(WaitingEndMove());
    }

    private IEnumerator WaitingEndMove()
    {
        while (_speed > 0)
        {          
            yield return null;
        }

        yield return StartCoroutine(_cameraAnimaton.MoveToPlayer(_player));
        _animator.SetTrigger(WinKey);
        EndedWaiting?.Invoke();
        yield return null;
    }

    private void OnMoved(float speed)
    {
        _speed = speed;
        _animator.SetFloat(SpeedKey, _speed);
    }
}
