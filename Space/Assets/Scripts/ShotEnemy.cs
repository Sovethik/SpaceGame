using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : MonoBehaviour
{
    public GameObject patron;
    public float time = 2f;
    public AudioSource AudioSourceShot;

    private void Start()
    {
        StartCoroutine(shooting());
    }


    IEnumerator shooting()
    {
        while (true)
        {
            Instantiate(patron, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(new Vector2(0, 0)));
            AudioSourceShot.Play();
            yield return new WaitForSeconds(time);
        }
    }
}
