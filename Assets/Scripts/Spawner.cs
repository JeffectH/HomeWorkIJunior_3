using UnityEngine;

public class Spawner
{
    private int _minNumberCube = 2;
    private int _maxNumberCube = 6;

    public void Spawn(Cube originalCube, float probabilityNewCubes, Vector3 pointSpawn, Vector3 beforeScaleValue)
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= probabilityNewCubes)
        {
            randomValue = Random.Range(_minNumberCube, _maxNumberCube);

            for (int i = 0; i < randomValue; i++)
            {
                Cube cube = GameObject.Instantiate(originalCube, pointSpawn, Quaternion.identity);
                cube.Initialize(probabilityNewCubes, beforeScaleValue);
            }
        }
    }
}
