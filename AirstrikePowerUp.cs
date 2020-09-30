using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class AirstrikePowerUp : MonoBehaviour
{
    public ParticleSystem Effect;
    public GameObject Rocket;
    public float RocketSpeed;

    private Transform FirePoint;
    private XRGrabInteractable Interactable;

    void Awake()
    {
        Interactable = GetComponent<XRGrabInteractable>();
        Effect.Play();
        GameObject[] FirePoints = GameObject.FindGameObjectsWithTag("AirStrike");
        FirePoint = FirePoints[0].transform;
    }

    void Update()
    {
        if (Interactable.selectingInteractor != null)
        {
            List<Target> Targets = new List<Target>();
            foreach (var target in Targets)
            {
                GameObject FiredRocket = Instantiate(Rocket, FirePoint.position, Quaternion.identity);
                Rigidbody RocketBody = FiredRocket.GetComponent<Rigidbody>();
                FiredRocket.transform.LookAt(target.transform);
                Vector3 direction = new Vector3(0, 0, 1);
                RocketBody.AddRelativeForce(direction * RocketSpeed * Time.deltaTime);
            }
            Destroy(gameObject);
        }
    }
}
