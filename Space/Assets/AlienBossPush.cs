using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBossPush : MonoBehaviour
{
    GameObject Player;
    public int offset;
    public GameObject Patron;
    public float TimeShot = 1;
    public GameObject Live;
    public GameObject Live2;

    private void Start()
    {
        Player = GameObject.Find("Player");
        StartCoroutine(Shot());
    }

    private void Update()
    {
       
       if (Live.GetComponent<AlienBossLive>().heath > 0 || Live2.GetComponent<AlienBossLive>().heath > 0)
       {
           var direction = Player.transform.position - transform.position;
           var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           transform.rotation = Quaternion.Euler(0, 0, angle + offset);
       }
        
    }

    IEnumerator Shot()
    {
        while(Live.GetComponent<AlienBossLive>().heath > 0 || Live2.GetComponent<AlienBossLive>().heath > 0)
        {
            var direction = Player.transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + offset);

            Instantiate(Patron, new Vector2(transform.position.x, transform.position.y),
                        Quaternion.Euler(new Vector3(0, 0, angle + offset)));

            yield return new WaitForSeconds(TimeShot);
        }    
    }
}
