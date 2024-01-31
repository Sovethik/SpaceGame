using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLazer : MonoBehaviour
{
    public Transform Player;
    public Animator En;
    public Animator En2;
    public float random;
    public GameObject lazer;
    public GameObject BossCenterPush;
    public Animator BossReh;
    public GameObject fire;
    public Animator bom;
    float time = 3f;
    public GameObject Bom;
    public AudioSource audioSourceLazer;
    public GameObject SpawnOb;
    bool controllerCorutine = true;//Что бы запустить корутину 1 раз

    private void Start()
    {
        StartCoroutine(shot());
    }
    private void FixedUpdate()
    {
        if (BossCenterPush.GetComponent<BossPushCenter>().heath <= 0)
        {
            if (controllerCorutine)
            {
                SpawnOb.SetActive(true);
                SpawnOb.GetComponent<SpawnEnemy>().Start();
                controllerCorutine = false;
            }
           
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 1), 1 * Time.deltaTime);

            En.Play("BossEn3");
            En2.Play("BossEn3");
            BossReh.Play("BossReh2");
            Destroy(fire);
            Destroy(gameObject, 3);
            bom.Play("BossBom");
            time -= Time.deltaTime;

            if(time <= 0)
            {
                Instantiate(Bom, new Vector2(transform.position.x, transform.position.y),
               Quaternion.Euler(new Vector2(0, 0)));
            }
        }
    }

    private void Update()
    {
        if (BossCenterPush.GetComponent<BossPushCenter>().heath > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 3.11f), 2 * Time.deltaTime);
        }
    }

    IEnumerator shot()
    {
        while(BossCenterPush.GetComponent<BossPushCenter>().heath > 0)
        {
            random = Random.Range(0, 2);
            if (transform.position.y < 3.3) 
            {

                if (Player.position.x > -0.5f && Player.position.x < 0.5f && random == 1)
                {
                    En.Play("BossEn2");
                    En2.Play("BossEn2");
                    Instantiate(lazer, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(new Vector2(0, 0)));
                    audioSourceLazer.Play();
                }
            }
            yield return new WaitForSeconds(2);

            En.Play("BossEn");
            En2.Play("BossEn");
        }
    }
}
