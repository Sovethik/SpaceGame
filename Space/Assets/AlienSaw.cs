using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSaw : MonoBehaviour
{
    public Animator Bom;
    public int heath = 1;
    public float destroyTime = 0;
    public int limitation = 0;//Счет
    public GameObject money;
    int RandomCoin;
    public string NameAnimBom;
    public GameObject saw;
    public GameObject SawBody;
    public int ShansSpawnCoin = 10;
    public AudioSource[] audiSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= heath;

        if (heath <= 0)
        {
            audiSource[0].Stop();
            audiSource[1].Play();
            audiSource[2].Play();
            SawBody.GetComponent<CircleCollider2D>().enabled = true;
            saw.transform.SetParent(null);
            saw.GetComponent<MoveOb>().speed = 6;

            Bom.Play(NameAnimBom);
            score.Score += limitation;
            //Монета
            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < ShansSpawnCoin)
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }
            Destroy(gameObject, destroyTime);
        }

    }
}
