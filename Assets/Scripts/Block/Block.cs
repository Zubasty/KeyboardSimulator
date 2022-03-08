using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Block : MonoBehaviour
{
    public Renderer Renderer { get; private set; }

    protected virtual void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }
}
