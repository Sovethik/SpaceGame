using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBoss : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public int offset;
    public GameObject IceBoll;
    public float timeShot = 1f;
    public int heath = 5;
    public GameObject Bom;
    public AudioSource [] audioSource;

    private void Start()
    {
        Player = GameObject.Find("Player");
        StartCoroutine(shot());
    }

    private void FixedUpdate()
    {
        if (heath > 0)
        {
            var direction = Player.transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + offset);
        }
    }

    IEnumerator shot()
    {
        while(heath > 0)
        {
            var direction = Player.transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Instantiate(IceBoll, new Vector2(transform.position.x, transform.position.y),
                Quaternion.Euler(new Vector3(0, 0, angle + offset)));

            yield return new WaitForSeconds(timeShot);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patron")
            heath--;

        if (heath <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            audioSource[0].Stop();
            audioSource[1].Play();
            audioSource[2].Play();
            Game.ScoreCoin += 50;
            Instantiate(Bom, new Vector2(transform.position.x, transform.position.y),
                Quaternion.Euler(new Vector2(0, 0)));
        }
    }
}
