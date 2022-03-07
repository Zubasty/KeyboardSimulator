using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CameraFollower))]
public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _resultAngle;
    [SerializeField] private float _speedAnimation;

    private CameraFollower _follower;

    private void Awake()
    {
        _follower = GetComponent<CameraFollower>();
    }

    public IEnumerator MoveToPlayer(Player player)
    {
        _follower.enabled = false;
        float percentComplition = 0;
        Vector3 startPosition = transform.position;
        Vector3 resultPosition = player.transform.position + _offset;
        Quaternion startAngle = transform.rotation;
        Quaternion endAngle = Quaternion.Euler(_resultAngle);

        while(transform.position != resultPosition)
        {
            percentComplition += _speedAnimation * Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, resultPosition, percentComplition);
            transform.rotation = Quaternion.Lerp(startAngle, endAngle, percentComplition);
            yield return null;
        }

        yield return null;
    }
}
