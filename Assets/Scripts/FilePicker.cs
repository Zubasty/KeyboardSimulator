using SFB;
using UnityEngine;
using System.IO;
using System;

public class FilePicker : MonoBehaviour
{
    public event Action<string> CanceledChoose;
    public event Action<string, string> GotText;

    public void OpenFileSelector()
    {
        var extensions = new[] { new ExtensionFilter("Text files", "txt") };

        string[] paths = StandaloneFileBrowser.OpenFilePanel(
            "Выберите файл с текстом, на котором будете тренироваться",
            "",
            extensions,
            false
        );

        if (paths.Length > 0)
        {
            string filePath = paths[0];
            //Debug.Log("Выбран файл: " + filePath);

            try
            {
                string content = File.ReadAllText(filePath);
                GotText?.Invoke(filePath, content);
            }
            catch (Exception e)
            {
                //Debug.LogError($"Не удалось прочитать файл: {e.Message}");
                CanceledChoose?.Invoke("Непредвиденная ошибка. Возможно проблемы с правами доступа к файлу.");
            }
        }
        else
        {
            //Debug.Log("ПЕРЕДУМАЛ");
            CanceledChoose?.Invoke("Файл не выбран.");
        }
    }
}