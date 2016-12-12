using UnityEngine;
using System.Collections;

public class LightOff : MonoBehaviour {

    public GameObject lightTrigger;
	void OnTriggerEnter () {
        var LightSwitch = lightTrigger.GetComponent<Light>();
        if (LightSwitch.enabled)
            LightSwitch.enabled = false;
        else
            LightSwitch.enabled = true;
    }

}
