using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;

    [field: SerializeField]public float SplitChance { get; private set; }

    public void Initialize(float splitChance)
    {
        SplitChance = splitChance;
        _renderer.material.color = Random.ColorHSV();
    }
}