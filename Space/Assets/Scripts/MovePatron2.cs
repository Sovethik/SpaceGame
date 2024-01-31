using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatron2 : MonoBehaviour
{
    public float speed = 15f;

    private void FixedUpdate()
    {
        if (true)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

            if (transform.position.y < -5.2f)
            {
                Destroy(gameObject);
            }
        }
    }
}
