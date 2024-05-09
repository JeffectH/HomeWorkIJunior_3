using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _expousionRadius;
    [SerializeField] private float _expousionForce;
    [SerializeField] private Camera _mainCamera;

    public event Action<float,Vector3, Vector3> Expode—ube;

    public void HittingCube() 
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) ) 
        {
            if (hit.collider.TryGetComponent(out Cube cube)) 
            {
                Expode—ube?.Invoke(cube.ProbabilityNewCubes, cube.transform.position, cube.ScaleValue);

                Expode(cube.transform.position);

                Destroy(cube.gameObject);
            }
        }
    }

    private void Expode(Vector3 pointExplode)
    {
        foreach (Rigidbody explodableObjects in GetExplousionObjects(pointExplode)) 
        {
            explodableObjects.AddExplosionForce(_expousionForce, pointExplode, _expousionRadius);
            explodableObjects.GetComponent<Cube>().ChangeStateForExplosion();
        }
    }

    private List<Rigidbody> GetExplousionObjects(Vector3 pointExplode)
    {
        Collider[] hits = Physics.OverlapSphere(pointExplode, _expousionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                if(hit.GetComponent<Cube>().WasCreatedRightNow)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
