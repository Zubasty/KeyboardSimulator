using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerAnimation))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _goodClip;
    [SerializeField] private AudioClip _badClip;
    [SerializeField] private AudioClip _endClip;

    private AudioSource _audio;
    private Player _player;
    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _player = GetComponent<Player>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        _player.SetedTarget += OnSetedTarget;
        _player.AddedLose += OnAddedLose;
        _playerAnimation.EndedWaiting += Win;
    }

    private void OnDisable()
    {
        _player.SetedTarget -= OnSetedTarget;
        _player.AddedLose -= OnAddedLose;
        _playerAnimation.EndedWaiting -= Win;
    }

    private void OnSetedTarget(Block newTarget)
    {
        _audio.PlayOneShot(_goodClip);
    }

    private void Win()
    {
        _audio.PlayOneShot(_endClip);
    }

    private void OnAddedLose(int countLose)
    {
        _audio.PlayOneShot(_badClip);
    }
}
