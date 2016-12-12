using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomTarget : MonoBehaviour
{

    public Transform Capsule;
    private static int score;
    public static int TargetNumber = 0;
    public Text Ttime;
    public Text Tscore;
    public Text Ttargets;

    float t = 0f;
    float GlobalT = 0f;
    void Update()
    {

        t += Time.deltaTime;
        GlobalT += Time.deltaTime;
        score = DestroyTarget.playerScore;

        if ((t > 2) && (TargetNumber <= 20))
        {
            t = 0;
            TargetNumber++;
            Quaternion rot = new Quaternion(0, 0, 0, 0);//transform.rotation;
            int randomIndexX = Random.Range(-15, 15);
            int randomIndexY = Random.Range(2, 10);
            int randomIndexZ = Random.Range(-15, 15);

            Vector3 randVec = new Vector3(randomIndexX, randomIndexY, randomIndexZ);
            Instantiate(Capsule, randVec, rot);
            Ttargets.text = "Targets: " + TargetNumber.ToString();
        }
        Ttime.text = "Time: " + Mathf.Round(GlobalT).ToString();
        Tscore.text = "Score: " + score.ToString();        
    }
}
