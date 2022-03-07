using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _player;

    private ParticleSystem _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        _player.EndedWaiting += Play;
    }

    private void OnDisable()
    {
        _player.EndedWaiting -= Play;       
    }

    private void Play()
    {
        _particle.Play();
    }
}
