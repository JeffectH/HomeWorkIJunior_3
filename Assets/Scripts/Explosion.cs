using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _expousionRadius;
    [SerializeField] private float _expousionForce;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private int _inputValue = 0;

    public event Action<float,Vector3, Vector3> Expode—ube;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_inputValue))
            Hitting—ube();
    }

    private void Hitting—ube() 
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) ) 
        {
            if (hit.collider.TryGetComponent(out Cube cube)) 
            {
                Expode(cube.transform.position);
                Expode—ube?.Invoke(cube.ProbabilityNewCubes, cube.transform.position, cube.ScaleValue);
                Destroy(cube.gameObject);
            }
        }
    }

    private void Expode(Vector3 pointExplode)
    {
        foreach (Rigidbody explodableObjects in GetExplousionObjects())
            explodableObjects.AddExplosionForce(_expousionForce, transform.position, _expousionRadius);
    }

    private List<Rigidbody> GetExplousionObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _expousionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
