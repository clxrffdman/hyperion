using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    public ParticleSystem Effect;
    public float Damage;
    public int Hits;
    public Transform Offset;

    private Collider collider;
    private MeshRenderer renderer;
    private Rigidbody body;
    private int HitsLeft;
    private bool HasBeenEquipped;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        HitsLeft = Hits;
        Effect.Play();

        collider.enabled = false;
        renderer.enabled = false;
    }

    void Update()
    {
        if (HitsLeft <= 0)
        {
            IsFull = false;
            Destroy(gameObject);
        }
    }

    void Activate()
    {
        collider.enabled = true;
        renderer.enabled = true;
    }

    void DeActivate()
    {
        collider.enabled = false;
        renderer.enabled = false;
    }

    void OnEquip()
    {
        transform.position = User.position + Offset.position;
        transform.rotation = Offset.rotation;
        transform.parent = User;
        Effect.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Target>().TakeDamage(Damage);
        }
        HitsLeft -= 1;
    }
}
