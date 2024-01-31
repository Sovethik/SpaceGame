using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crystal : MonoBehaviour
{
    public float controller = 0;
    public GameObject Ob;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
            controller = 1;
            Ob.GetComponent<MoveOb>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if (controller > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(2.1f, -1.8f), 4 * Time.deltaTime);
            if (transform.position.x == 2.1f && transform.position.y == -1.8f)
            {
                Game.ScoreCrystal += 1;
                Destroy(Ob);
            }
        }

    }
}
