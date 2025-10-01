using TMPro;
using UnityEngine;

[RequireComponent(typeof(BlockSymbol))]
public class BlockSymbolView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private BlockSymbol _block;

    private void Awake()
    {
        _block = GetComponent<BlockSymbol>();
    }

    private void Start()
    {
        if (_block.Symbol.ToString() == "\n") _text.text = "⏎";
        else _text.text = _block.Symbol.ToString();      
    }
}
