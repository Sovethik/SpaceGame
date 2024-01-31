using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPatron : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Untagged" && collision.tag != "Patron2")
            Destroy(gameObject);
    }
}
