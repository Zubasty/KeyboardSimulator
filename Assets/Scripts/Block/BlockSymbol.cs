using UnityEngine;

public class BlockSymbol : Block
{
    [SerializeField] private char _symbol;
    [SerializeField] private ParticleSystem _particlePass;
    [SerializeField] private ParticleSystem _particleFall;

    public char Symbol => _symbol;

    protected override void Awake()
    {
        base.Awake();
        Renderer.material.color = Color.white;
    }

    public void Initialization(char symbol)
    {
        _symbol = symbol;
    }

    public void Use()
    {
        _particlePass.Play();
        Renderer.material.color = Color.green;
    }

    public void Wait() 
    {
        Renderer.material.color = Color.yellow;   
    }

    public void Fall()
    {
        Renderer.material.color = Color.red;
        _particleFall.Play();
    }
}
