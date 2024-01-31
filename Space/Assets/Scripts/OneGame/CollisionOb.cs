using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOb : MonoBehaviour
{
    public Animator Bom;
    public GameObject Obj;
    public int heath = 1;
    public float destroyTime = 0;
    public int limitation = 0;
    public GameObject money;
    int RandomCoin;
    public string NameAnim;
    public int ShansSpawnCoin = 10;
    public AudioSource SourceBom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= heath;

        if (heath <= 0)
        {
            SourceBom.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            Bom.Play(NameAnim);
            score.Score += limitation;
            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < ShansSpawnCoin)
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }
            Destroy(Obj, destroyTime);
        }
            
    }
}
