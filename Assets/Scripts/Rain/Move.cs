using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Vector3 tempPos;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        tempPos = transform.position;
        tempPos.x += h * speed * Time.deltaTime;
        tempPos.y += v * speed * Time.deltaTime;

        if (tempPos.y <= 0)
            tempPos.y = -4;
        if (tempPos.x <= -6.8f)
            tempPos.x = -6.8f;
        if (tempPos.x >= 6.8f)
            tempPos.x = 6.8f;
        transform.position = tempPos;

        // body.velocity = new Vector2(h * speed, v * speed);
    }
}

