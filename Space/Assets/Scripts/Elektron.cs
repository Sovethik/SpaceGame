using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elektron : MonoBehaviour
{
    public Animator Shok;
    public int controller = 1;
    bool controllerSounds = true;
    public float time = 1;
    public AudioSource SoudsShok;
    public AudioSource Souds;

    private void FixedUpdate()
    {
        if (time > 0 && controller <= 0)
            time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            Shok.Play("Electron3");
            if (controllerSounds)
            {
                SoudsShok.Play();
                controllerSounds = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Patron")
        {
            Souds.Stop();
            controller--;
            if(controller <= 0)
            {
                Shok.Play("Electron2");
                if (time <= 0 && collision.tag == "Player")
                {
                    if(CollisionPlayer.IndexSkins == 2)
                    {
                        CollisionPlayer.heath -= 1;
                    }

                    else
                    {
                        CollisionPlayer.heath -= 3;
                    }
                    
                }
            }
            
        }
    }

}
