using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _expousionRadius;
    [SerializeField] private float _expousionForce;
    [SerializeField] private Camera _mainCamera;

    public void HittingCube() 
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) ) 
        {
            if (hit.collider.TryGetComponent(out Cube cube)) 
            {
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
        }
    }

    private List<Rigidbody> GetExplousionObjects(Vector3 pointExplode)
    {
        Collider[] hits = Physics.OverlapSphere(pointExplode, _expousionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
