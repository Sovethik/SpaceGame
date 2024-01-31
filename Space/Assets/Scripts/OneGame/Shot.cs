using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject patron;
    public Transform Player;
    public static float timer;
    public static float[] TimeShot = { 1f, 1f, 0.9f, 0.9f, 0.8f, 0.8f };
    public AudioSource[] shoot;

    private void Start()
    {
        StartCoroutine(shooting());
    }
    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            timer = 0;
        }
    }


    IEnumerator shooting()
    {
        while (!Game.lose)
        {
            while (!Game.lose && timer == 0)
            {
                shoot[0].Play();
                Instantiate(patron, new Vector2(Player.position.x, Player.position.y), Quaternion.Euler(new Vector2(0, 0)));
                yield return new WaitForSeconds(TimeShot[CollisionPlayer.IndexSkins]);
            }

            while (!Game.lose && timer > 0)
            {
                shoot[1].Play();
                Instantiate(patron, new Vector2(Player.position.x, Player.position.y), Quaternion.Euler(new Vector2(0, 0)));
                yield return new WaitForSeconds(0.1f);
                shoot[2].Play();
                Instantiate(patron, new Vector2(Player.position.x, Player.position.y), Quaternion.Euler(new Vector2(0, 0)));
                yield return new WaitForSeconds(0.1f);
                shoot[3].Play();
                Instantiate(patron, new Vector2(Player.position.x, Player.position.y), Quaternion.Euler(new Vector2(0, 0)));
                yield return new WaitForSeconds(0.7f);
            }
        }
        
    }

    
              
}
