using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BlockSymbol _template;
    [SerializeField] private BlockFinish _finishTemplate;
    [SerializeField] private Road _road;

    public void Spawn(string text)
    {
        Block[] blocks = new Block[text.Length + 1];

        for (int i = 0; i < text.Length; i++)
        {
            BlockSymbol block = Instantiate(_template, new Vector3(i * _template.transform.localScale.x, 0, 0), Quaternion.identity);
            block.Initialize(text[i]);
            blocks[i] = block;
        }

        blocks[text.Length] = Instantiate(_finishTemplate, new Vector3(text.Length * _template.transform.localScale.x, 0, 0), Quaternion.identity);
        _road.Initialization(blocks);
    }
}
