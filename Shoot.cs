using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    public float HitScore;
    public GameObject MuzzleFlash;
    public GameObject Impact;
    public float FireRate;
    public float Force;
    public float Damage = 20f;

    float range = 100f;
    public Transform Barrel;

    private XRGrabInteractable Interactable;
    private float TimeTillFire;
    private InputDevice Controller;
    private bool CanShoot;

    void Start()
    {
        Interactable = GetComponent<XRGrabInteractable>();
        MuzzleFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Interactable.selectingInteractor != null)
        {
            Controller = Interactable.selectingInteractor.transform.GetComponent<XRController>().inputDevice;
            CanShoot = true;
        }
        else
        {
            CanShoot = false;
        }

        if (Time.time >= TimeTillFire && CanShoot && Controller.TryGetFeatureValue(CommonUsages.trigger, out float TriggerValue))
        {
            if (TriggerValue >= 0.8f)
            {
                 TimeTillFire = Time.time + 1f / FireRate;
                 Shootgun();
                 MuzzleFlash.SetActive(true);
            }
            else
            {
                MuzzleFlash.SetActive(false);
            }

        }
    }
    void Shootgun()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Barrel.position, Barrel.forward, out Hit, range))
        {
            targetOld Targethit = Hit.transform.GetComponent<targetOld>();
            Rigidbody TargetHitBody = Hit.transform.GetComponent<Rigidbody>();
            if (Targethit != null)
            {
                Targethit.TakeDamage(Damage);
                Score.score += HitScore;
            }
            if (TargetHitBody != null)
            {
                TargetHitBody.AddForce(-Hit.normal * Force);
            }


            GameObject SpawnedImpact = Instantiate(Impact, Hit.point, Quaternion.LookRotation(Hit.normal));
            Destroy(SpawnedImpact, 0.5f);
        }
    }
}
