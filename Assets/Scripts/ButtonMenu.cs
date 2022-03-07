using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _textInput;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _textInput.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {       
        _textInput.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(string text)
    {
        _button.interactable = text.Length > 0;
    }
}
