using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Animator lazer;
    bool shot;
    bool controller;

    private void Start()
    {
        lazer.Play("Lazer3");
        Destroy(gameObject, 3.2f);
        controller = true;
    }
    private void FixedUpdate()
    {
        if(BossPushCenter.controllerShot == 1)
        {
            BossPushCenter.controllerShot = 0;
            Destroy(gameObject);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            shot = true;
        if (controller) 
        {
            StartCoroutine(domag());
            controller = false;
        }
    }

    IEnumerator domag()
    {
        while (true)
        {
            if (shot) 
            {
                CollisionPlayer.heath--;
                shot = false;
            }
            yield return new WaitForSeconds(0.4f);
        }
    }
}
