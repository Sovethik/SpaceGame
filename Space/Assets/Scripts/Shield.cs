using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Animator anim;
    public GameObject shield;
    public GameObject shell;
    public AudioSource audioSource;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Patron" || collision.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            audioSource.Play();
            anim.Play("Shield_1");
            Destroy(gameObject, 1.4f);
            LivePlayer.timer = 8;
            LivePlayer.TimeLive = CollisionPlayer.heath;
        }

  
    }
   
}
