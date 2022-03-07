using UnityEngine;
using IJunior.TypedScenes;

public class MenuInitializater : MonoBehaviour, ISceneLoadHandler<bool>
{
    [SerializeField] private AudioSource _backgroundMusic;

    public void OnSceneLoaded(bool isStart = true)
    {
        if (isStart)
        {
            Instantiate(_backgroundMusic);
        }
    }
}
