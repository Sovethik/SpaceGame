using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBigMeteor : MonoBehaviour
{
    public Animator Bom;
    public GameObject Obj;
    public int heath = 1;
    public float destroyTime = 0;
    public int limitation = 0;
    public GameObject money;
    public int RandomCoin;
    public string NameAnimator;
    public int ShansSpawnCoin = 10;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (collision.tag == "Player")
            heath -= 10;

        if (heath <= 0)
        {
            audioSource.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            Bom.Play(NameAnimator);
            limitation = 4;
            RandomCoin = Random.Range(0, 100);
            if (RandomCoin < ShansSpawnCoin)
            {
                Instantiate(money, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
            }
            Destroy(Obj, destroyTime);
            score.Score += limitation;
        }

    }
}
