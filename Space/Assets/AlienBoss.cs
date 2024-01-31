using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoss : MonoBehaviour
{
    GameObject Player;
    public float TimeShot = 1;
    public GameObject Live;
    public GameObject Live2;
    public GameObject Patron;
    public AudioSource[] audioSource;

    private void Start()
    {
        Player = GameObject.Find("Player");
        StartCoroutine(shot());
    }

    private void Update()
    {
        if (Live.GetComponent<AlienBossLive>().heath > 0 || Live2.GetComponent<AlienBossLive>().heath > 0) 
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(Player.transform.position.x, 3), 0.7f * Time.deltaTime);
        }

        else
        {
            audioSource[0].Stop();
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(5, 0), 2f * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 45) * 5 * Time.deltaTime);
            Destroy(gameObject, 8);
        }
    }

    IEnumerator shot()
    {
        while(Live.GetComponent<AlienBossLive>().heath > 0 || Live2.GetComponent<AlienBossLive>().heath > 0)
        {
            if (Player.transform.position.x > transform.position.x - 0.7f && Player.transform.position.x < transform.position.x + 0.7f)
            {
                Instantiate(Patron, new Vector2(transform.position.x, transform.position.y),
                    Quaternion.Euler(new Vector2(0, 0)));
                audioSource[1].Play();
            }

            yield return new WaitForSeconds(TimeShot);
        }
    }
}
