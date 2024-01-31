using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelpShip : MonoBehaviour
{
    public int speed = 2;

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y < -6.5f || transform.position.y > 7.5)
            Destroy(gameObject);
    }
}
