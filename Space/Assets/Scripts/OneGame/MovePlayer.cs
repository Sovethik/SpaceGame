using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform Player;
    [SerializeField]
    private float speed = 3;
    public static float time = 0;

    private void Update()
    {
        if(time > 0)
        {
            speed = 1.5f;
            time -= Time.deltaTime;
        }

        if(time < 0)
        {
            time = 0;
            speed = 3;
        }
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = mousePos.x > 1.85f ? 1.85f : mousePos.x;
        mousePos.x = mousePos.x < -1.85f ? -1.85f : mousePos.x;

        Player.position = Vector2.MoveTowards(Player.position, new Vector2(mousePos.x, Player.position.y),
            speed * Time.deltaTime);
    }
}
