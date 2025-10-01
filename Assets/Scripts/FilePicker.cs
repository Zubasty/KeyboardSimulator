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
            "�������� ���� � �������, �� ������� ������ �������������",
            "",
            extensions,
            false
        );

        if (paths.Length > 0)
        {
            string filePath = paths[0];
            //Debug.Log("������ ����: " + filePath);

            try
            {
                string content = File.ReadAllText(filePath);
                GotText?.Invoke(filePath, content);
            }
            catch (Exception e)
            {
                //Debug.LogError($"�� ������� ��������� ����: {e.Message}");
                CanceledChoose?.Invoke("�������������� ������. �������� �������� � ������� ������� � �����.");
            }
        }
        else
        {
            //Debug.Log("���������");
            CanceledChoose?.Invoke("���� �� ������.");
        }
    }
}