using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai_tracer : MonoBehaviour
{
    private Transform target;

    public float speed;
    public LayerMask PlayerLayer;

    private Animator m_Animator;

    private void Start()
    {
        target = GameObject.Find("Ship").transform;
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("isShoot", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
        transform.LookAt(target);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerLifes>().LoseLife();
        }
    }
}