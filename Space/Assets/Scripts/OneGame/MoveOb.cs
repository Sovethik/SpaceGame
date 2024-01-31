using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOb : MonoBehaviour
{
    public float speed = 3;
    public int controller;

    private void Start()
    {
        if(controller < 4)
            controller = Random.Range(0, 3);

        if (controller == 0)
            speed = 2.8f;
        if (controller == 1)
            speed = 3f;
        if (controller == 2)
            speed = 3.2f;
    }


    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -6.5f || transform.position.y > 7.5)
            Destroy(gameObject);
    }
}
