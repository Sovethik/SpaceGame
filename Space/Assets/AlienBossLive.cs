using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBossLive : MonoBehaviour
{
    public int heath = 1;
    public Animator live;
    public GameObject Bom;
    public AudioSource audioSource, audioSourceCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (heath <= 0)
        {
            audioSourceCoin.Play();
            Game.ScoreCoin += 35;
            audioSource.Play();
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(Bom, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            live.Play("AlienBossLive2");
        }

    }
}
