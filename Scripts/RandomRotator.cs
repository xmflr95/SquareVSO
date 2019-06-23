using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float rotateSpeed = 3f;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, rotateSpeed));
    }

}
