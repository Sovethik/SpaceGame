using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkHelpShip : MonoBehaviour
{
    public Animator HelpShip;
    public GameObject Ships;
    public AudioSource audioSource;

    public int controller = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Patron" || collision.tag == "Player")
        {
            audioSource.Play();
            HelpShip.Play("PerkHelpShip1");
            Destroy(gameObject, 0.3f);

            controller--;

            if(controller == 0)
            {
                Instantiate(Ships, new Vector2(-1.8f, -6), Quaternion.Euler(new Vector2(0, 0)));
                Instantiate(Ships, new Vector2(1.8f, -6), Quaternion.Euler(new Vector2(0, 0)));
            }
        }

    }
}
