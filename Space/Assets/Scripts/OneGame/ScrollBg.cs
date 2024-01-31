using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour
{
    public GameObject BackGround;
    public float speed = 3;
    private void Update()
    {

        transform.Translate(Vector2.down * speed * Time.deltaTime);
        

        if (transform.position.y < -10.5f)
        {
            Instantiate(BackGround, new Vector2(0, 41.83f), Quaternion.Euler(new Vector2(0, 0)));
            Destroy(gameObject);
        }
    }

    
}
