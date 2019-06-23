using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject effect;
    public float speed = 5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        //움직일 거리 계산
        float distanceY = speed * Time.deltaTime;
        //y축 반영
        //this.gameObject.transform.Translate(0, -1 * distanceY, 0);        
        this.gameObject.transform.Translate(Vector2.down * distanceY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
