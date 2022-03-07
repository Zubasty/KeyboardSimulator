using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    private Dictionary<KeyCode, string> _keySymbols = new Dictionary<KeyCode, string>()
    {
        { KeyCode.A, "‘ÙAa" },
        { KeyCode.S, "€˚Ss" },
        { KeyCode.D, "¬‚Dd" },
        { KeyCode.F, "¿‡Ff" },
        { KeyCode.G, "œÔGg" },
        { KeyCode.H, "–Hh" },
        { KeyCode.J, "ŒÓJj" },
        { KeyCode.K, "ÀÎKk" },
        { KeyCode.L, "ƒ‰Ll" },
        { KeyCode.Q, "…ÈQq" },
        { KeyCode.W, "÷ˆWw" },
        { KeyCode.E, "”ÛEe" },
        { KeyCode.R, " ÍRr" },
        { KeyCode.T, "≈ÂTt" },
        { KeyCode.Y, "ÕÌYy" },
        { KeyCode.U, "√„Uu" },
        { KeyCode.I, "ÿ¯Ii" },
        { KeyCode.O, "Ÿ˘Oo" },
        { KeyCode.P, "«ÁPp" },
        { KeyCode.Z, "ﬂˇZz" },
        { KeyCode.X, "◊˜Xx" },
        { KeyCode.C, "—ÒCc" },
        { KeyCode.V, "ÃÏVv" },
        { KeyCode.B, "»ËBb" },
        { KeyCode.N, "“ÚNn" },
        { KeyCode.M, "‹¸Mm" },
        { KeyCode.Semicolon, ";:∆Ê" },
        { KeyCode.LeftBracket, "[{’ı" },
        { KeyCode.RightBracket, "]}⁄˙" },
        { KeyCode.Comma, ",<¡·" },
        { KeyCode.Period, ".>ﬁ˛" },
        { KeyCode.Slash, "/?.," },
        { KeyCode.Alpha0, "0)" },
        { KeyCode.Alpha1, "1!" },
        { KeyCode.Alpha2, "2\"@" },
        { KeyCode.Alpha3, "3#π" },
        { KeyCode.Alpha4, "4;$" },
        { KeyCode.Alpha5, "5%" },
        { KeyCode.Alpha6, "6:^" },
        { KeyCode.Alpha7, "7&?" },
        { KeyCode.Alpha8, "8*" },
        { KeyCode.Alpha9, "9(" },
        { KeyCode.Quote, "'\"›˝" },
        { KeyCode.Space, " " },
        { KeyCode.Plus, "+=" },
        { KeyCode.Minus, "-ó_" }
    };
    
    public bool HaveKeySymbol(KeyCode key, char symbol)
    {
        return _keySymbols[key].IndexOf(symbol) != -1;
    }

    public IEnumerable<KeyCode> Keys
    {
        get
        {
            return _keySymbols.Keys;
        }
    }
}
