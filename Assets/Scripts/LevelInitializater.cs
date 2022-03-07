using UnityEngine;
using IJunior.TypedScenes;

public class LevelInitializater : MonoBehaviour, ISceneLoadHandler<string>
{
    [SerializeField] private Spawner _spawner;

    public string Text { get; private set; }

    public void OnSceneLoaded(string text)
    {
        Text = text;
        _spawner.Spawn(Text);
    }
}
