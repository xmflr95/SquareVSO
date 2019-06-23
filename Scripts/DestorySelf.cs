using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour {

    public float destroySelfTime = 7f; // 3s

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroySelfTime);
	}
	
}
