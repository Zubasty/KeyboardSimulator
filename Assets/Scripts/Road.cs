using UnityEngine;

public class Road : MonoBehaviour
{
    private Block[] _blocks;

    public int CountBlocks => _blocks.Length;

    public void Initialization(Block[] blocks)
    {
        _blocks = blocks;
    }

    public char GetSymbol(int number)
    {
        BlockSymbol block = GetBlock(number) as BlockSymbol;

        if (block)
        {
            return block.Symbol;
        }

        throw new System.Exception("Áëîê íå ÿâëÿåòñÿ ñèìâîëüíûì");
    }

    public Block GetBlock(int number) 
    {
        if (number >= 0 && number < _blocks.Length)
        {
            return _blocks[number];
        }

        throw new System.Exception("Áëîê íå ñóùåñòâóåò");
    }
}
