using UnityEngine;
using UnityEngine.EventSystems;

public class UIMovePlayer1 : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform Player;
    public float speed = 30f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (true)
        {
            Vector2 delta = eventData.delta;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                if (delta.x > 0 && Player.position.x < 1.6f)
                {

                    Player.position = Vector2.MoveTowards(Player.position, new Vector2(delta.x, Player.position.y),
                        speed * Time.deltaTime);
                }
                if (delta.x < 0 && Player.position.x > -1.6f)
                {

                    Player.position = Vector2.MoveTowards(Player.position, new Vector2(delta.x, Player.position.y),
                        speed * Time.deltaTime);
                }
            }
        }
    }
}
