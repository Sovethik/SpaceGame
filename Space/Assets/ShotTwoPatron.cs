using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTwoPatron : MonoBehaviour
{
    public GameObject Patron;
    public float Position;
    public AudioSource audioSourceShot;

    private void Start()
    {
        StartCoroutine(shot());
    }

    IEnumerator shot()
    {
        while(true)
        {
            Instantiate(Patron, new Vector2(transform.position.x - Position, transform.position.y - 0.1f), 
                Quaternion.Euler(new Vector2(0, 0)));

            Instantiate(Patron, new Vector2(transform.position.x + Position, transform.position.y - 0.1f),
                Quaternion.Euler(new Vector2(0, 0)));
            audioSourceShot.Play();

            yield return new WaitForSeconds(2f);
        }
    }
}
