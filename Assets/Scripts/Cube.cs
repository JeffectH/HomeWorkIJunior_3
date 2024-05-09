using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _reductionValueProbability;
    [SerializeField] private float _reductionValueScale;
    [SerializeField] private float _probabilityNewCubes;
    [SerializeField] private bool _wasCreatedRightNow = false;

    public float ProbabilityNewCubes => _probabilityNewCubes;
    public bool WasCreatedRightNow => _wasCreatedRightNow;
    public Vector3 ScaleValue => transform.localScale;

    public void Inisialize(float probabilityNewCubes, Vector3 scaleValue)
    {
        _probabilityNewCubes = probabilityNewCubes;
        transform.localScale = scaleValue;

        ChangeStateForExplosion();
        ReducingProbability();
        DecreaseScale();
        GenerateNevColor();
    }

    public void ChangeStateForExplosion() => _wasCreatedRightNow=!_wasCreatedRightNow;

    private void ReducingProbability() =>
        _probabilityNewCubes /= _reductionValueProbability;

    private void DecreaseScale() =>
        transform.localScale /= _reductionValueScale;

    private void GenerateNevColor()
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomColor;
    }
}
