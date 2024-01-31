using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHelpShip : MonoBehaviour
{
    public GameObject patron;
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(shoting()); 
    }

   IEnumerator shoting()
   {
        while(true)
        {
            audioSource.Play();
            Instantiate(patron, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
                Quaternion.Euler(new Vector2(0, 0)));
            yield return new WaitForSeconds(0.5f);
        }
   }
}
