using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [Header("��������")]
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _minSpeed = 1f;
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _deceleration = 8f;
    [SerializeField] private float _brakingDistance = 2f; // ��������� ��� ������ ���������� ����� �����

    private Rigidbody _rigidbody;
    private Queue<Block> _targets = new Queue<Block>();
    private float _currentSpeed = 0f;

    public event System.Action<float> Moved;

    public bool IsMoving => _currentSpeed > 0.01f || _targets.Count > 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_targets.Count == 0)
        {
            // ������ ���������������
            _currentSpeed = Mathf.Max(0, _currentSpeed - _deceleration * Time.deltaTime);
        }
        else
        {
            Block currentTarget = _targets.Peek();
            float distanceToTarget = currentTarget.transform.position.x - transform.position.x;

            bool isNearFinish = _targets.Count == 1 && distanceToTarget < _brakingDistance;

            if (isNearFinish)
            {
                // ������ �������� ����� �������
                _currentSpeed = Mathf.Max(_minSpeed, _currentSpeed - _deceleration * Time.deltaTime);
            }
            else
            {
                // ���������� �� ���������
                _currentSpeed = Mathf.Min(_maxSpeed, _currentSpeed + _acceleration * Time.deltaTime);
            }

            // ��������� ������
            float moveX = _currentSpeed * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + Vector3.right * moveX);

            // �������� ����?
            if (transform.position.x >= currentTarget.transform.position.x)
            {
                _targets.Dequeue();
            }
        }

        // ���������� ������� �������� � ��������
        Moved?.Invoke(_currentSpeed);
    }

    public void AddTarget(Block target)
    {
        _targets.Enqueue(target);
    }
}