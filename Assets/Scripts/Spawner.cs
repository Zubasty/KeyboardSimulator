using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BlockSymbol _template;
    [SerializeField] private BlockFinish _finishTemplate;
    [SerializeField] private string _text;
    [SerializeField] private Road _road;

    private void Awake()
    {
        Block[] blocks = new Block[_text.Length + 1]; 

        for(int i = 0; i< _text.Length; i++)
        {
            BlockSymbol block = Instantiate(_template, new Vector3(i * _template.transform.localScale.x, 0, 0), Quaternion.identity);
            block.Initialization(_text[i]);
            blocks[i] = block;
        }

        blocks[_text.Length] = Instantiate(_finishTemplate, new Vector3(_text.Length * _template.transform.localScale.x, 0, 0), Quaternion.identity);
        _road.Initialization(blocks);
    }
}
