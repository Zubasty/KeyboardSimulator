using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Mover))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Player _player;
    private Mover _mover;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        Move(_player.Target);
        transform.position = _player.Target.transform.position + _offset;       
    }

    private void OnEnable()
    {
        _player.SetedTarget += Move;
    }

    private void OnDisable()
    {
        _player.SetedTarget -= Move;       
    }

    private void Move(Block target) 
    {
        _mover.NewTarget(target);
    }
}
