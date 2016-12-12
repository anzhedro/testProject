using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    void pause()
    {
        Time.timeScale = 0;
        //while (!Input.GetKeyDown("p"))
        //{
        //    Debug.Log("bitch");
        //}
        //Time.timeScale = 1;
    }
    void resume()
    {
        Time.timeScale = 1;
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Debug.Log(f.ToString());
            yield return new WaitForSeconds(.1f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            StartCoroutine("Fade");
            //Fade();
            //pause();
            //Time.timeScale = 0;
        }
    }
}
