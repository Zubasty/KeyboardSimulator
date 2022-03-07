using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;
using TMPro;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _button.onClick.AddListener(GameLoad);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(GameLoad);       
    }

    private void GameLoad()
    {
        Game.Load(_text.text.Substring(0, _text.text.Length-1));
    }
}