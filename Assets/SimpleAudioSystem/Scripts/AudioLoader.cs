using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioLoader : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer _masterMixer;

    [Header("Ключи")]
    [SerializeField] private string[] _keys;

    void Start()
    {
        foreach(string key in _keys)
        {
            float linearValue = PlayerPrefs.GetFloat(key, 1f);
            float dB = AudioUtils.LinearToDecibels(linearValue);
            _masterMixer.SetFloat(key, dB);
        }
    }
}
