using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKomet : MonoBehaviour
{
    public float speedX = 2;
    public float speedY = 2;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speedX * Time.deltaTime);
        transform.Translate(Vector2.down * speedY * Time.deltaTime);
        if (transform.position.x < -4 || transform.position.x > 4)
            Destroy(gameObject);
    }
}
