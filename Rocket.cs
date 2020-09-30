using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public LayerMask TargetLayer;
    public float Radius;
    public float Damage;

    void OnCollisionEnter(Collision other)
    {
        RaycastHit hit;
        Vector3 Direction = new Vector3(0, 1, 0);
        if (Physics.SphereCast(transform.position, Radius, Direction, out hit, 0.01f, TargetLayer))
        {
            Target Targethit = hit.transform.GetComponent<Target>();
            if (Targethit != null)
            {
                Targethit.TakeDamage(Damage);
            }
        }
    }
}
