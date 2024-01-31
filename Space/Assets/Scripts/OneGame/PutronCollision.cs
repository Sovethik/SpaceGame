using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutronCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mine" || other.tag =="Meteor Big" || other.tag == "Meteor Midle" || other.tag == "Meteor Little"
            || other.tag == "Enemy")
            Destroy(gameObject);
    }
}
