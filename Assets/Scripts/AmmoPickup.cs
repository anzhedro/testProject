using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {
    public AudioClip pickupSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Shot.spareRounds < Shot.maxRounds)
        {
            GetComponent<AudioSource>().PlayOneShot(pickupSound);
            Shot.spareRounds += 7;
            Destroy(gameObject.transform.parent.gameObject, pickupSound.length);
        }
    }
}
