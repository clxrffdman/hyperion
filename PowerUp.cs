using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PowerUp : MonoBehaviour
{
    public InputDevice Hand;
    public Transform User;
    public bool IsFull = false;

    private GameObject EquippedPowerUp;



    void Update()
    {
        if (Hand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerValue >= 0.8)
            {
                EquippedPowerUp.SendMessage("Activate");
            }
            else
            {
                EquippedPowerUp.SendMessage("DeActivate");
            }
        }
        FindAllPowerUps();
    }

    void FindAllPowerUps()
    {
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
        foreach (var powerUp in powerUps)
        {
            if (Vector3.Distance(transform.position, powerUp.transform.position) >= 0.2f)
            {
                EquippedPowerUp = powerUp;
                EquippedPowerUp.SendMessage("OnEquip");
                IsFull = true;
            }
        }
    }
}