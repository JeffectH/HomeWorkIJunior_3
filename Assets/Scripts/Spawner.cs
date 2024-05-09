using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Explosion _explosion;
    [SerializeField, Range(2, 6)] private int _minNumberCube;
    [SerializeField, Range(2, 6)] private int _maxNumberCube;

    private void OnValidate()
    {
        if (_minNumberCube >= _maxNumberCube)
            _minNumberCube = _maxNumberCube++;
    }

    private void OnEnable()
    {
        _explosion.Expode—ube += Spawn;
    }

    private void OnDisable()
    {
        _explosion.Expode—ube -= Spawn;
    }

    public void Spawn(float probabilityNewCubes, Vector3 pointSpawn, Vector3 beforeScaleValue)
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= probabilityNewCubes)
        {
            randomValue = Random.Range(_minNumberCube, _maxNumberCube);

            for (int i = 0; i < randomValue; i++)
            {
                Cube cube = Instantiate(_cubePrefab, pointSpawn, Quaternion.identity);
                cube.Inisialize(probabilityNewCubes, beforeScaleValue);
            }
        }
    }
}
