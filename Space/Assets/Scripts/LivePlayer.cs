using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePlayer : MonoBehaviour
{
    public Animator live;
    public GameObject StartOver;
    public GameObject shell;
    public GameObject Shield;


    public static float timer = 0;
    public static int TimeLive = 0;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            CollisionPlayer.heath = TimeLive;
            shell.SetActive(true);
            Shield.SetActive(true);

        }
        if (timer < 0)
        {
            timer = 0;
            shell.SetActive(false);
            Shield.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        if (CollisionPlayer.heath == 5)
            live.Play("Lv");
        else
        {
            if (CollisionPlayer.heath == 4)
                live.Play("Lv2");

            if (CollisionPlayer.heath == 3)
                live.Play("Lv3");

            if (CollisionPlayer.heath == 2)
                live.Play("Lv4");

            if (CollisionPlayer.heath == 1)
                live.Play("Lv5");

            if (CollisionPlayer.heath <= 0)
            {
                live.Play("Lv6");
                Game.lose = true;
                StartOver.SetActive(true);
            }
        }
    }
}
