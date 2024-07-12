using System.Collections.Generic;
using UnityEngine;

public class Explosion
{
    private float _expousionRadius = 20f;
    private float _expousionForce = 300f;

    public void Expode(Vector3 pointExplode)
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
