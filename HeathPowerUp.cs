using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HeathPowerUp : MonoBehaviour
{
    public ParticleSystem Effect;

    private GameObject PlayerShip;
    private PlayerLifes PlayerHealth;
    private XRGrabInteractable Interactable;

    void Awake()
    {
        Interactable = GetComponent<XRGrabInteractable>();
        PlayerShip = GameObject.Find("Ship");
        PlayerHealth = PlayerShip.GetComponent<PlayerLifes>();
        Effect.Play();
    }

    void Update()
    {
        if (Interactable.selectingInteractor != null)
        {
            if (PlayerHealth.CurrentLifes != PlayerHealth.Lifes)
            {
                PlayerHealth.CurrentLifes += 1;
            }
            Destroy(gameObject);
        }
    }
}
