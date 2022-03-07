using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    private Dictionary<KeyCode, string> _keySymbols = new Dictionary<KeyCode, string>()
    {
        { KeyCode.A, "��Aa" },
        { KeyCode.S, "��Ss" },
        { KeyCode.D, "��Dd" },
        { KeyCode.F, "��Ff" },
        { KeyCode.G, "��Gg" },
        { KeyCode.H, "��Hh" },
        { KeyCode.J, "��Jj" },
        { KeyCode.K, "��Kk" },
        { KeyCode.L, "��Ll" },
        { KeyCode.Q, "��Qq" },
        { KeyCode.W, "��Ww" },
        { KeyCode.E, "��Ee" },
        { KeyCode.R, "��Rr" },
        { KeyCode.T, "��Tt" },
        { KeyCode.Y, "��Yy" },
        { KeyCode.U, "��Uu" },
        { KeyCode.I, "��Ii" },
        { KeyCode.O, "��Oo" },
        { KeyCode.P, "��Pp" },
        { KeyCode.Z, "��Zz" },
        { KeyCode.X, "��Xx" },
        { KeyCode.C, "��Cc" },
        { KeyCode.V, "��Vv" },
        { KeyCode.B, "��Bb" },
        { KeyCode.N, "��Nn" },
        { KeyCode.M, "��Mm" },
        { KeyCode.Semicolon, ";:��" },
        { KeyCode.LeftBracket, "[{��" },
        { KeyCode.RightBracket, "]}��" },
        { KeyCode.Comma, ",<��" },
        { KeyCode.Period, ".>��" },
        { KeyCode.Slash, "/?.," },
        { KeyCode.Alpha0, "0)" },
        { KeyCode.Alpha1, "1!" },
        { KeyCode.Alpha2, "2\"@" },
        { KeyCode.Alpha3, "3#�" },
        { KeyCode.Alpha4, "4;$" },
        { KeyCode.Alpha5, "5%" },
        { KeyCode.Alpha6, "6:^" },
        { KeyCode.Alpha7, "7&?" },
        { KeyCode.Alpha8, "8*" },
        { KeyCode.Alpha9, "9(" },
        { KeyCode.Quote, "'\"��" },
        { KeyCode.Space, " " },
        { KeyCode.Plus, "+=" },
        { KeyCode.Minus, "-�_" }
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
