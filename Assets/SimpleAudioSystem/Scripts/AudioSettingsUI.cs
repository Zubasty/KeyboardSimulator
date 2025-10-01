using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioSettingsUI : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer _masterMixer;

    [Header("Ключ звука")]
    [SerializeField] private string _key;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        float volume = PlayerPrefs.GetFloat(_key, 1f); ;
        _slider.value = volume;
    }

    private void Start()
    {
        SetVolume(_slider.value);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float linearValue)
    {
        PlayerPrefs.SetFloat(_key, linearValue);
        PlayerPrefs.Save();
        
        float dB = AudioUtils.LinearToDecibels(linearValue);
        _masterMixer.SetFloat(_key, dB);
    }
}