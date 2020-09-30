using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DamageBoostPowerUp : MonoBehaviour
{
    public ParticleSystem Effect;

    private GameObject PlayerShip;
    private Shoot PlayerGun;
    private XRGrabInteractable Interactable;

    void Awake()
    {
        Interactable = GetComponent<XRGrabInteractable>();
        PlayerShip = GameObject.Find("Ship");
        PlayerGun = PlayerShip.GetComponent<Shoot>();
        Effect.Play();
    }

    void Update()
    {
        if (Interactable.selectingInteractor != null)
        {
            PlayerGun.Damage += 10;
            Destroy(gameObject);
        }
    }
}
