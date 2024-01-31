using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMidleMeteor : MonoBehaviour
{
    public Animator Bom;
    public GameObject Obj;
    public int heath = 1;
    public float destroyTime = 0;
    public int limitation = 0;
    public GameObject money;
    public int RandomCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= 10;

        if (heath <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Bom.Play("BomMidleMeteor");
            score.Score += limitation;
            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < 5) 
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }
            Destroy(Obj, destroyTime);
        }

    }
}
