using UnityEngine;

public class BlockFinish : Block
{
    protected override void Awake()
    {
        base.Awake();
        Renderer.material.color = Color.green;
    }
}
