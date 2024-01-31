using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPush : MonoBehaviour
{
    [SerializeField] private Transform Player;
    public float offset;
    public GameObject patron;
    public float SpeedShot = 1.5f;
    public float Min_X;
    public float Max_X;
    public int heath = 2;
    public Animator destroy;
    public Animator circle;
    public GameObject fire;
    public GameObject bom;
    public GameObject lazer;
    public AudioSource audioSourceShot;
    public AudioSource audioSourceBom;

    private void Start()
    {
        StartCoroutine(shooting());
    }
    //поворот
    void Update()
    {
        if (Player.position.x > Min_X && Player.position.x < Max_X && heath > 0) 
        {
            var direction = Player.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + offset);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Patron")
        {
            heath--;
        }

        if (heath == 0)
        {
            destroy.Play("BossPush2");
            circle.Play("BossRight2");
            Destroy(fire);
            audioSourceBom.Play();
            Instantiate(bom, new Vector2(transform.position.x, transform.position.y),
                Quaternion.Euler(new Vector2(0, 0)));
        }
    }

    IEnumerator shooting()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("lazer").Length == 0) 
            {
                if (Player.position.x > Min_X && Player.position.x < Max_X && heath > 0)
                {
                    var direction = Player.position - transform.position;
                    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, angle + offset);
                    Instantiate(patron, new Vector2(transform.position.x, transform.position.y),
                                Quaternion.Euler(new Vector3(0, 0, angle + offset)));
                    audioSourceShot.Play();
                }
            }
            yield return new WaitForSeconds(SpeedShot);
        }
    }
}
