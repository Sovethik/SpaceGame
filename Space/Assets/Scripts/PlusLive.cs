using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusLive : MonoBehaviour
{
    public Animator Heath;
    public int live = 3;
    public AudioSource[] audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
        {
            live--; 
        }

        if (collision.tag == "Player")
            live -= 3;

        if (live == 3)
        {
            Heath.Play("Heath");
            audioSource[1].Play();
        }
        else
        {
            if (live == 2)
            {
                Heath.Play("Heath_2");
                audioSource[1].Play();
            }
            if (live == 1)
            {
                Heath.Play("Heath_3");
                audioSource[1].Play();
            }
            if (live <= 0)
            {
                audioSource[0].Play();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                CollisionPlayer.heath++;
                LivePlayer.TimeLive++;
                Heath.Play("Heath_4");
                Destroy(gameObject, 0.25f);
            }
        }
    }
}
