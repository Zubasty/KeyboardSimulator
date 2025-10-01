using UnityEngine;

public class LevelInitializater : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public string Text { get; private set; }

    public void Start()
    {
        //Debug.Log(TypeTextSwitcher.TEXT_FOR_GAME);
        Text = TypeTextSwitcher.TEXT_FOR_GAME;
        _spawner.Spawn(Text);
    }
}
