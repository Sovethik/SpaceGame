using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBoll : MonoBehaviour
{
    public float TimeBom = 1.5f;
    public Animator Bom;
    public float speed;
    public GameObject IceBollSmall;
    bool controller;
    public AudioSource audioSource;

    private void Start()
    {
        controller = true;
    }

    private void FixedUpdate()
    {
        TimeBom -= Time.deltaTime;

        if(TimeBom <= 0 && controller)
        {
            audioSource.Play();
            controller = false;
            Instantiate(IceBollSmall, new Vector2(transform.position.x, transform.position.y),
                Quaternion.Euler(new Vector3(0, 0, transform.rotation.z * 100)));
            Instantiate(IceBollSmall, new Vector2(transform.position.x, transform.position.y),
                Quaternion.Euler(new Vector3(0, 0, transform.rotation.z * 100 - 10)));
            Instantiate(IceBollSmall, new Vector2(transform.position.x, transform.position.y),
                Quaternion.Euler(new Vector3(0, 0, transform.rotation.z * 100 + 10)));
            speed = 0;
            Bom.Play("IceBoll2");
            Destroy(gameObject, 0.2f);
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -5.2f)
        {
            Destroy(gameObject);
        }
    }
}
