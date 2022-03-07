using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Block : MonoBehaviour
{
    private Renderer _renderer;

    public Renderer Renderer => _renderer;

    protected virtual void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
}
