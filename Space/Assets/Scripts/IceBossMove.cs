using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBossMove : MonoBehaviour
{
    public bool controller;
    public GameObject IceBossHeat;
    public Animator destroy;

    private void Start()
    {
        controller = true;
    }

    private void FixedUpdate()
    {
        if (transform.position.y != 3.5f && IceBossHeat.GetComponent<IceBoss>().heath > 0)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 3.5f), 1 * Time.deltaTime);

        if (transform.position.y == 3.5f && IceBossHeat.GetComponent<IceBoss>().heath > 0)
        {
            if(controller)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(1.7f, 3.5f), 1 * Time.deltaTime);
                if (transform.position.x == 1.7f)
                    controller = false;
            }

            if(!controller)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-1.7f, 3.5f), 1 * Time.deltaTime);
                if (transform.position.x == -1.7f)
                    controller = true;
            }
        }

        if(IceBossHeat.GetComponent<IceBoss>().heath <= 0)
        {
            destroy.Play("IceBoss2");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(5, 0), 2 * Time.deltaTime);
            Destroy(gameObject, 5);
        }
    }

    
}
