using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucer : MonoBehaviour
{
    public int heath = 3;
    public GameObject flyingSaucer;
    public Animator Bom;
    public GameObject money;
    public int RandomCoin;
    public int ShansSpawnCoin = 10;
    public AudioSource[] audiSource;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= 10;

        if (heath == 2)
        {
            flyingSaucer.GetComponent<FlyingSaucerMove>().controller = true;
            audiSource[0].Play();
        }

        if(heath <= 0)
        {
            audiSource[1].Play();
            flyingSaucer.GetComponent<FlyingSaucerMove>().speed = 3;
            Bom.Play("Flying saucer2");
            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < ShansSpawnCoin)
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }

            Destroy(flyingSaucer, 0.4f);
        }
    }
}
