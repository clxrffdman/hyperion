using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class Hands : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> ControllerPrefabs;

    private InputDevice TargetDevice;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            TargetDevice = devices[0];
            GameObject prefab = ControllerPrefabs.Find(controller => controller.name == TargetDevice.name);
            if (prefab)
            {
                Instantiate(prefab, transform);
            }
        }

        foreach (var Item in devices)
        {
            Debug.Log(Item.name + Item.characteristics);
        }

    }
}
