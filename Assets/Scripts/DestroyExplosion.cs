using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour {
	
	void Start() {
        Destroy(gameObject, 3.5f);
    }
}
