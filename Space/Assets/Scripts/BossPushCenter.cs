using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPushCenter : MonoBehaviour
{
    [SerializeField] private Transform Player;
    public float offset;
    public GameObject patron;
    public float SpeedShot = 1.5f;
    public GameObject Push;
    public GameObject Push2;
    public int heath;
    public Animator destroy;
    public GameObject bom;
    public static int controllerShot = 0;
    public AudioSource audioSourceShot;
    
    private void Start()
    {
        StartCoroutine(shooting());
    }

    void Update()
    {
        //поворот
        if ((Push.GetComponent<BossPush>().heath <= 0 || Push2.GetComponent<BossPush>().heath <= 0) && heath > 0)
        {
            var direction = Player.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + offset);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Push.GetComponent<BossPush>().heath <= 0 && Push2.GetComponent<BossPush>().heath <= 0)
        {
            if (collision.tag == "Patron")
                heath--;
            if (heath == 0)
            {
                controllerShot = 1;
                destroy.Play("BossPushCenter2");
                Instantiate(bom, new Vector2(transform.position.x, transform.position.y),
               Quaternion.Euler(new Vector2(0, 0)));
            }
        }
    }

    IEnumerator shooting()
    {
        while (heath > 0)
        {
            
            if (Push.GetComponent<BossPush>().heath <= 0 || Push2.GetComponent<BossPush>().heath <= 0)
            {

                var direction = Player.position - transform.position;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle + offset);

                Instantiate(patron, new Vector2(transform.position.x - 0.05f, transform.position.y),
                                        Quaternion.Euler(new Vector3(0, 0, angle + offset)));
                audioSourceShot.Play();
                Instantiate(patron, new Vector2(transform.position.x + 0.05f, transform.position.y),
                                        Quaternion.Euler(new Vector3(0, 0, angle + offset)));
                audioSourceShot.Play();

            }
            
            yield return new WaitForSeconds(SpeedShot);

        }
    }
}
