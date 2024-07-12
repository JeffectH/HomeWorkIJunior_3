using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    public event Action<float, Vector3, Vector3> DestroyCube;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _reductionValueProbability;
    [SerializeField] private float _reductionValueScale;
    [SerializeField] private float _probabilityNewCubes;

    public float ProbabilityNewCubes => _probabilityNewCubes;
    public Vector3 ScaleValue => transform.localScale;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    public void Initialize(float probabilityNewCubes, Vector3 scaleValue)
    {
        _probabilityNewCubes = probabilityNewCubes;
        transform.localScale = scaleValue;

        ReducingProbability();
        DecreaseScale();
        GenerateNevColor();
    }

    private void ReducingProbability() =>
        _probabilityNewCubes /= _reductionValueProbability;

    private void DecreaseScale() =>
        transform.localScale /= _reductionValueScale;

    private void GenerateNevColor()
    {
        Color randomColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomColor;
    }

    private void OnDisable()
    {
        _spawner.Spawn(ProbabilityNewCubes, transform.position, ScaleValue);
    }
}
