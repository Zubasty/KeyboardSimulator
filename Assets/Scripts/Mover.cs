using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Queue<Block> _targets;

    public event Action<float> Moved;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targets = new Queue<Block>();
    }

    private void Update()
    {
        if(_targets.Count != 0)
        {
            float speed = _speed * Time.deltaTime * _targets.Count;
            _rigidbody.MovePosition(new Vector3(transform.position.x + speed, transform.position.y, transform.position.z));

            if(transform.position.x > _targets.Peek().transform.position.x)
            {
                _targets.Dequeue();
            }

            Moved?.Invoke(_targets.Count);
        }
    }

    public void AddTarget(Block target)
    {
        _targets.Enqueue(target);
    }
}
