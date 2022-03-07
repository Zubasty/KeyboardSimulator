using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cursor : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _player.SetedTarget += MoveToBlock;
    }

    private void OnDisable()
    {
        _player.SetedTarget -= MoveToBlock;
    }

    private void Start()
    {
        MoveToBlock(_player.Target);
    }

    private void MoveToBlock(Block block)
    {
        _rigidbody.MovePosition(block.transform.position + _offset);
    }
}
