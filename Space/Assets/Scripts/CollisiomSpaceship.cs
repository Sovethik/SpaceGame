using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisiomSpaceship : MonoBehaviour
{
    public Animator Bom;
    public int heath = 1;
    public float destroyTime = 0;
    public int limitation = 0;
    public GameObject money;
    public int RandomCoin;
    public int ShansSpawnCoin = 10;
    public AudioSource SourceBom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= 10;
        if (heath <= 0 )
        {
            SourceBom.Play();
            Bom.Play("BomSpaceShip");
            GetComponent<BoxCollider2D>().enabled = false;



            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < ShansSpawnCoin)
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }
            Destroy(gameObject, destroyTime);
            score.Score += limitation;
        }

    }
}
