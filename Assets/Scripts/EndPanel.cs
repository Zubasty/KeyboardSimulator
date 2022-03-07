using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class EndPanel : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;

    private CanvasGroup _group;
    
    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _playerAnimation.EndedWaiting += On;
    }

    private void OnDisable()
    {
        _playerAnimation.EndedWaiting -= On;
    }

    private void On()
    {
        _group.alpha = 1;
        _group.blocksRaycasts = true;
        _group.interactable = true;
        _text.text = $"Ты справился с текстом за {_timer.Time.TotalSeconds} с.\nТвое количество ошибок: {_player.CountLose}.";
    }
}
