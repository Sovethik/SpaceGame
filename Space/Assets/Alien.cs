using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Animator Bom;
    public int heath = 1;
    public float destroyTime = 0;
    public int limitation = 0;
    public GameObject money;
    int RandomCoin;
    public int ShansDropCoin = 10;
    public string NameAnim;
    public GameObject destroyObj;
    public AudioSource[] audiSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= heath;
        

        if (heath == 0)
        {
            audiSource[0].Stop();
            audiSource[1].Play();
            Bom.Play(NameAnim);
            score.Score += limitation;
            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < ShansDropCoin)
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }
            Destroy(destroyObj, destroyTime);
        }

    }
}

