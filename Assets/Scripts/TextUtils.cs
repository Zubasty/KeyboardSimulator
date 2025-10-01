using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class TextUtils
{
    private const int MAX_LINE_ON_SCREEN = 30;
    public static string CleanText(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "";

        // 1. Заменяем "редкие" символы
        string cleaned = input
                        // Переносы строк
                        .Replace("\r\n", "\n")
                        .Replace('\r', '\n')
                        .Replace('\u2028', '\n')
                        .Replace('\u2029', '\n')
                        // Тире
                        .Replace('—', '-')  // EM DASH дефис
                        .Replace('–', '-')  // EN DASH дефис
                        // Кавычки
                        .Replace('“', '"')  // LEFT DOUBLE QUOTATION MARK
                        .Replace('”', '"')  // RIGHT DOUBLE QUOTATION MARK
                        .Replace('„', '"')  // GERMAN QUOTES (низкие)
                        .Replace('«', '"')  // Французские ёлочки
                        .Replace('»', '"')
                        // Апострофы и одинарные кавычки
                        .Replace('‘', '\'')
                        .Replace('’', '\'')
                        .Replace('‚', '\'')
                        // Многоточие
                        .Replace("…", "...");

        // 2. Заменяем все whitespace (кроме \n) на пробел
        cleaned = Regex.Replace(cleaned, @"[^\S\n]", " ");

        // 3. Чистим дубли
        cleaned = Regex.Replace(cleaned, @" +", " ");     // пробелы
        cleaned = Regex.Replace(cleaned, @"\n+", "\n");   // переносы

        // 4. Убираем пробелы по краям строк и всего текста
        cleaned = Regex.Replace(cleaned, @"^[ \t]+|[ \t]+$", "", RegexOptions.Multiline);
        cleaned = cleaned.Trim();

        return cleaned;
    }
    public static List<Tuple<int, string>> GetScreenText(string input)
    {
        string[] groups = CleanText(input).Split('\n');
        List<Tuple<int, string>> res = new List<Tuple<int, string>>();
        int firstNumb = 0;

        for (int g = 0; g < groups.Length; g++)
        {
            string group = groups[g];
            string[] splitSpace = group.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            string nowLine = "";

            // Если группа пустая — добавляем только ↵
            if (splitSpace.Length == 0)
            {
                res.Add(new Tuple<int, string>(firstNumb, "⏎"));
                firstNumb++;
                continue;
            }

            for (int i = 0; i < splitSpace.Length; i++)
            {
                string word = splitSpace[i];

                if (nowLine == "" && word.Length > MAX_LINE_ON_SCREEN)
                {
                    // Режем длинное слово
                    for (int j = 0; j < word.Length; j += MAX_LINE_ON_SCREEN)
                    {
                        int len = Mathf.Min(MAX_LINE_ON_SCREEN, word.Length - j);
                        string part = word.Substring(j, len);
                        res.Add(new Tuple<int, string>(firstNumb + part.Length - 1, part));
                        firstNumb += part.Length;
                    }
                }
                else
                {
                    string testLine = nowLine == "" ? word : nowLine + " " + word;

                    if (testLine.Length <= MAX_LINE_ON_SCREEN)
                    {
                        nowLine = testLine;
                    }
                    else
                    {
                        // Сохраняем текущую строку
                        if (nowLine != "")
                        {
                            res.Add(new Tuple<int, string>(firstNumb + nowLine.Length, nowLine));
                            firstNumb += nowLine.Length + 1;
                        }

                        // Обрабатываем текущее слово
                        if (word.Length > MAX_LINE_ON_SCREEN)
                        {
                            nowLine = "";
                            i--; // вернёмся к этому слову
                        }
                        else
                        {
                            nowLine = word;
                        }
                    }
                }
            }

            // Добавляем остаток строки
            if (nowLine != "")
            {
                res.Add(new Tuple<int, string>(firstNumb + nowLine.Length - 1, nowLine));
                firstNumb += nowLine.Length;
            }

            // Добавляем ↵ в конец абзаца — ТОЛЬКО если в res есть хотя бы одна строка
            if (res.Count > 0)
            {
                var last = res[res.Count - 1];
                res[res.Count - 1] = new Tuple<int, string>(last.Item1 + 1, last.Item2 + (g < groups.Length - 1 ? "⏎" : ""));
                if (g<groups.Length)
                    firstNumb++;
            }
            else
            {
                throw new Exception("Ну типа текста нет, а пытаемся запустить игру, всё окей??");
            }
        }

        return res;
    }
}