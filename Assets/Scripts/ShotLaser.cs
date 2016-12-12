using UnityEngine;
using System.Collections;

public class ShotLaser : MonoBehaviour
{
    public Transform barrelEnd;
    public GameObject LaserEffect;
    public AudioClip LaserShotSound;
    public static bool isHit = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject gun1 = Camera.main.transform.GetChild(0).gameObject;
            gun1.SetActive(true);
            Shot.isActive = true;
            gameObject.SetActive(false);
        }        

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(Camera.main.transform.position, barrelEnd.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            GameObject LaserClone = (GameObject)Instantiate(LaserEffect, barrelEnd.position, barrelEnd.rotation);
            GetComponent<AudioSource>().PlayOneShot(LaserShotSound);
            Destroy(LaserClone, LaserShotSound.length);

            if ((hit.collider != null) && (hit.collider.name == "Target(Clone)"))
            {
                float distance = hit.distance/* Mathf.Sqrt(Mathf.Pow((hit.collider.transform.position.x - barrelEnd.transform.position.x), 2f) + Mathf.Pow((hit.collider.transform.position.y - barrelEnd.transform.position.y), 2f) + Mathf.Pow((hit.collider.transform.position.z - barrelEnd.transform.position.z), 2f))*/;                
                Destroy(LaserClone, distance / 25f);
                Destroy(hit.collider.gameObject, distance / 25f);
                isHit = true;
                DestroyTarget.playerScore++;
                RandomTarget.TargetNumber--;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            gameObject.transform.localPosition = new Vector3(0f, -0.293f, 0.833f);
            gameObject.transform.Rotate(0f, -10f, 0f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            gameObject.transform.localPosition = new Vector3(0.448f, -0.293f, 0.833f);
            gameObject.transform.Rotate(0f, 10f, 0f);
        }
    }
}
