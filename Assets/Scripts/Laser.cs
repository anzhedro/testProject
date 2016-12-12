using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public float LaserSpeed = 20f;
    void Update () {
        transform.position += transform.forward * LaserSpeed * Time.deltaTime;
    }
    //void OnCollisionEnter()
    //{
    //    Destroy(gameObject);
    //}
}
