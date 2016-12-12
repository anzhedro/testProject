using UnityEngine;
using System.Collections;

public class DestroyTarget : MonoBehaviour
{
    public static int playerScore;
    void OnCollisionEnter(Collision collision)
    {
        playerScore++;
        RandomTarget.TargetNumber--;
        Destroy(gameObject);
    }
}
