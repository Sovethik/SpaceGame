using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkThreePatron : MonoBehaviour
{
    public GameObject Player;
    public Animator Anim;
    public AudioSource audioSource;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Patron" || collision.tag == "Player")
        {
            audioSource.Play();
            Shot.timer = 15;
            Anim.Play("ThreePatron_2");
            Destroy(gameObject, 0.45f);
        }
    }
}
