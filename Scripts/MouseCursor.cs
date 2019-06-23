using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

    private SpriteRenderer rend;
    public Sprite handCursor;
    public Sprite normalCursor;

    public GameObject clickEffect;
    public GameObject clickPos;

    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0))
        {
            rend.sprite = handCursor;
            Instantiate(clickEffect, clickPos.transform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rend.sprite = normalCursor;
        }
    }
}
