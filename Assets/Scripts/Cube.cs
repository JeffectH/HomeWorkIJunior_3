using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _reductionValueProbability;
    [SerializeField] private float _reductionValueScale;
    [SerializeField] private float _probabilityNewCubes;

    private Explosion _explosion;
    private Spawner _spawner;

    private void Awake()
    {
        _explosion = new Explosion();
        _spawner = new Spawner();
    }

    private void OnMouseDown()
    {
        _explosion.Expode(transform.position);
        _spawner.Spawn(this, _probabilityNewCubes, transform.position, transform.localScale);
        Destroy(gameObject);
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
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = randomColor;
    }
}
