using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour
{
    public float pulseSpeed = 1.5f;

    public float maxWidth = 0.5f;
    public float minWidth = 0.2f;

    public LineRenderer lRenderer;
    public GameObject pointer;

    public float maxDist = 200.0f;

    void Start()
    {
        StartCoroutine("ChoseNewAnimationTargetCoroutine");
    }

    IEnumerator ChoseNewAnimationTargetCoroutine()
    {
        while (true)
        {
            minWidth = minWidth * 0.8f + Random.Range(0.1f, 1.0f) * 0.2f;
            yield return new WaitForSeconds(Random.value * 2.0f);
        }
    }


    void Update()
    {
        float aniFactor = Mathf.PingPong(Time.time * pulseSpeed, 1.0f);
        aniFactor = Mathf.Max(minWidth, aniFactor) * maxWidth;
        lRenderer.SetWidth(aniFactor, aniFactor);

        Ray ray = new Ray(Camera.main.transform.position, lRenderer.gameObject.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lRenderer.SetPosition(1, (hit.distance * Vector3.forward));

            pointer.GetComponent< Renderer > ().enabled = true;
            pointer.transform.position = hit.point/* + (transform.position - hit.point) * 0.01f*/;
            //pointer.transform.rotation = Quaternion.LookRotation(hit.normal, transform.up);
            //pointer.transform.eulerAngles.x = 90.0f;
            //pointer.transform.eulerAngles = new Vector3(90f, 0f, 0f);

        }
        else
        {
            pointer.GetComponent<Renderer>().enabled = false;
            lRenderer.SetPosition(1, (maxDist * Vector3.forward));
        }

    }
}
