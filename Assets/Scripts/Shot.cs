using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shot : MonoBehaviour
{
    public Rigidbody Bullet;
    public Transform barrelEnd;
    public GameObject muzzleParticles;
    public AudioClip flareShotSound;
    public AudioClip noAmmoSound;
    public AudioClip reloadSound;
    public Texture ammoTexture;
    public Text AmmoCount;
    public Text NoAmmo;

    public float BulletSpeed = 2000f;
    public static int maxRounds = 49;
    public static int spareRounds = 15;
    public static int currentRound = 7;
    public static bool isActive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject gun2 = Camera.main.transform.GetChild(1).gameObject;
            isActive = false;
            gun2.SetActive(true);
            gameObject.SetActive(false);

        }

        if (Input.GetButtonDown("Fire1") && !GetComponent<Animation>().isPlaying)
        {
            if (currentRound > 0)
            {
                Shoot();
            }
            else
            {
                GetComponent<Animation>().Play("noAmmo");
                GetComponent<AudioSource>().PlayOneShot(noAmmoSound);
            }
        }
        if (spareRounds >= 1 - currentRound && currentRound == 0)
        {
            AmmoCount.text = (currentRound.ToString() + "/" + spareRounds.ToString());
            AutoReload();
        }
        if (Input.GetKeyDown(KeyCode.R) && !GetComponent<Animation>().isPlaying)
        {
            AmmoCount.text = (currentRound.ToString() + "/" + spareRounds.ToString());
            Reload();
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.transform.localPosition = new Vector3(0f, -0.6f, 0.76f);
            gameObject.transform.Rotate(0f, 4f, 0f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            gameObject.transform.localPosition = new Vector3(0.34f, -0.6f, 0.76f);
            gameObject.transform.Rotate(0f, -4f, 0f);
        }
    }
    void Shoot()
    {
        currentRound--;
        if (currentRound <= 0)
        {
            currentRound = 0;
        }
        //GetComponent<Animation>().Stop();
        GetComponent<Animation>().CrossFade("Shoot");
        GetComponent<AudioSource>().PlayOneShot(flareShotSound);
        Rigidbody bulletInstance = (Rigidbody)Instantiate(Bullet, barrelEnd.position, barrelEnd.rotation);
        bulletInstance.AddForce(barrelEnd.forward * BulletSpeed);// rocketClone.velocity = transform.forward * BulletSpeed;
        Instantiate(muzzleParticles, barrelEnd.position, barrelEnd.rotation);   //INSTANTIATING THE GUN'S MUZZLE SPARKS
    }
    void AutoReload()
    {
        if (spareRounds >= 7)
        {
            GetComponent<AudioSource>().PlayOneShot(reloadSound);
            currentRound = 7;
            spareRounds -= 7;
            GetComponent<Animation>().CrossFade("Reload");
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(reloadSound);
            currentRound = spareRounds;
            spareRounds = 0;
            GetComponent<Animation>().CrossFade("Reload");
        }
    }
    void Reload()
    {
        if (spareRounds >= 7 - currentRound && currentRound != 7)
        {
            GetComponent<AudioSource>().PlayOneShot(reloadSound);
            GetComponent<Animation>().CrossFadeQueued("Reload");
            int n = 0;
            n = 7 - currentRound;
            spareRounds -= n;
            currentRound += n;
        }
        else
        {
            if (currentRound != 7)
            {
                GetComponent<AudioSource>().PlayOneShot(reloadSound);
                GetComponent<Animation>().CrossFadeQueued("Reload");
                currentRound += spareRounds;
                spareRounds = 0;
            }
        }
    }
}
