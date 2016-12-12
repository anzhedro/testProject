using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletsCount : MonoBehaviour
{
    public Text AmmoCount;
    public Text NoAmmo;
    public GameObject BulCon;
    GameObject ammo;
    //bool flag = true;

    void Update()
    {
        AmmoCount.enabled = true;
        AmmoCount.text = (Shot.currentRound.ToString() + "/" + Shot.spareRounds.ToString());
        if (Shot.spareRounds == 0 && Shot.currentRound == 0)
        {
            NoAmmo.enabled = true;
        }
        else
            NoAmmo.enabled = false;

        for (int i = 0; i < 7 - Shot.currentRound; i++)
        {
            ammo = BulCon.transform.GetChild(i).gameObject;
            ammo.SetActive(false);
        }
        for (int i = 7 - Shot.currentRound; i < 7; i++)
        {
            ammo = BulCon.transform.GetChild(i).gameObject;
            ammo.SetActive(true);
        }

    }
}
