using UnityEngine;

public class MenuInitializater : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;

    public void Awake()
    {
        Instantiate(_backgroundMusic);
    }
}
