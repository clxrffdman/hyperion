using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai_Shoot : MonoBehaviour
{
    public Transform PlayerShip;
    public GameObject Bullet;
    public float ShootDistance;
    public float ShootSpeed;
    public float MoveSpeed;
    public Transform Barrel;

    private float TimeTillShoot;
    private Animator m_Animator;

    void Awake()
    {
        PlayerShip = GameObject.Find("Ship").transform;
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("isShoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerShip);
        if (Vector3.Distance(transform.position, PlayerShip.position) > ShootDistance)
        {
            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
        }


        if (Time.time > TimeTillShoot)
        {
            TimeTillShoot = Time.time + 1 / ShootSpeed;
            Shoot();   
        }
    }

    private void Shoot()
    {
        m_Animator.SetBool("isShoot", true);
        Instantiate(Bullet, Barrel.position, Quaternion.identity);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
