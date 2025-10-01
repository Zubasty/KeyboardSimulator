using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class EndPanel : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _menuButton;
    [SerializeField] private LevelInitializater _levelInitializater;

    private CanvasGroup _group;
    
    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _playerAnimation.EndedWaiting += On;
        _restart.onClick.AddListener(Restart);
        _menuButton.onClick.AddListener(OnMenu);
    }

    private void OnDisable()
    {
        _playerAnimation.EndedWaiting -= On;
        _restart.onClick.RemoveListener(Restart);
        _menuButton.onClick.RemoveListener(OnMenu);
    }

    private void On()
    {
        _group.alpha = 1;
        _group.blocksRaycasts = true;
        _group.interactable = true;
        _text.text = $"Ты справился с текстом!\n"+
                     $"Частота ошибок: {Mathf.Round((float)((float)_player.CountLose/(_player.CountLose + TypeTextSwitcher.TEXT_FOR_GAME.Length))*100)}%.\n" +
                     $"Средняя скорость: {Mathf.Round((float)(TypeTextSwitcher.TEXT_FOR_GAME.Length*60/_timer.Time.TotalSeconds*100))/100} символов в минуту.\n";
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
