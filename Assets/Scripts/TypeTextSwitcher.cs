using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TypeTextSwitcher : MonoBehaviour
{
    private const int MAX_COUNT_SYMBOLS_FROM_FILE = 10000;
    public static string TEXT_FOR_GAME;

    [SerializeField] private FilePicker _filePicker;
    [SerializeField] private Button _fileButton;
    [SerializeField] private Button _textButton;
    [SerializeField] private GameObject _filePanel;
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TextMeshProUGUI _infoAboutFile;
    [SerializeField] private TMP_InputField _textField;
    [SerializeField] private Button _startGame;

    private string _textForGame;

    public string TextForGame
    {
        get { return _textForGame; }
        private set
        {
            _textForGame = value;
            TEXT_FOR_GAME = _textForGame;
            _startGame.interactable = value != "";
        }
    }

    private void Awake()
    {
        TextForGame = "";
    }

    private void OnEnable()
    {
        _filePicker.GotText += OnGotText;
        _filePicker.CanceledChoose += OnCanceledChoose;
        _fileButton.onClick.AddListener(ChoosingFile);
        _textField.onValueChanged.AddListener(OnChooseText);
        _textButton.onClick.AddListener(TakeFromFiled);
        _startGame.onClick.AddListener(OnStartGame);
    }

    private void OnDisable()
    {
        _filePicker.GotText -= OnGotText;
        _filePicker.CanceledChoose -= OnCanceledChoose;
        _fileButton.onClick.RemoveListener(ChoosingFile);
        _textField.onValueChanged.RemoveListener(OnChooseText);
        _textButton.onClick.RemoveListener(TakeFromFiled);
        _startGame.onClick.RemoveListener(OnStartGame);
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void TakeFromFiled()
    {
        TextForGame = TextUtils.CleanText(_textField.text);
        _filePanel.gameObject.SetActive(false);
        _textPanel.gameObject.SetActive(true);
    }

    private void OnChooseText(string text)
    {
        text = TextUtils.CleanText(text);
        TextForGame = text;
    }

    private void OnGotText(string path, string text)
    {
        text = TextUtils.CleanText(text);
        if(text.Length > MAX_COUNT_SYMBOLS_FROM_FILE)
        {
            _infoAboutFile.text = "Допускаются только файлы с количеством символов не больше " + MAX_COUNT_SYMBOLS_FROM_FILE.ToString() +
                ". А в файле " + path + " символов " + text.Length.ToString();
            return;
        }
        TextForGame = text;
        if(text == "")
            _infoAboutFile.text = "Выбран пустой файл: " + path;
        else
            _infoAboutFile.text = "Взят текст из файла: " + path;
    }

    private void OnCanceledChoose(string message)
    {
        _infoAboutFile.text = message;
        TextForGame = "";
    }

    private void ChoosingFile()
    {
        _filePicker.OpenFileSelector();
        _filePanel.gameObject.SetActive(true);
        _textPanel.gameObject.SetActive(false);
    }
}
