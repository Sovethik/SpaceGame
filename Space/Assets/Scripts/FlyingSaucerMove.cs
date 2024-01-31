using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSaucerMove : MonoBehaviour
{
    public float speed = 3;
    public bool controller = false;
    public int offset;
    [SerializeField] GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(controller)
        {
            var direction = Player.transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + offset);

            speed = 6;

            controller = false;
        }

        if (transform.position.y < -6.5f || transform.position.y > 7.5)
            Destroy(gameObject);
    }
}
