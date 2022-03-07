using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Player _player;

    private void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
