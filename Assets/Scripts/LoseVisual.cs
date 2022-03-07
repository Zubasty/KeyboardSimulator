using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class LoseVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.AddedLose += OnAddedLose;
    }

    private void OnDisable()
    {
        _player.AddedLose -= OnAddedLose;       
    }

    private void OnAddedLose(int countLose)
    {
        _text.text = countLose.ToString();
    }
}
