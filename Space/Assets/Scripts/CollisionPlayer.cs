using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    public static int heath = 5;
    public static int IndexSkins = 0;
    public Sprite[] Skins;
    private SpriteRenderer spriteRender;
    public static int[,] DamageSpace_0 = { { 3, 4, 1, 2, 4, 2, 1, 4, 3, 3}, { 3, 4, 1, 2, 4, 1, 1, 4, 3, 3 }, 
        { 3, 4, 1, 2, 4, 1, 1, 4, 3, 1 }, { 3, 4, 1, 2, 4, 1, 1, 3, 3, 3 }, { 3, 3, 1, 1, 4, 1, 1, 3, 3, 3 }, 
        { 2, 3, 1, 1, 3, 1, 1, 3, 3, 3 }};

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = Skins[IndexSkins];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (heath > 5)
            heath = 5;
        if (collision.tag == "Enemy")
        {
            if(IndexSkins == 5)
            {
                heath -= 2;
            }
            else
                heath -= 3;
        }
            
        if (collision.tag == "Meteor Big")
        {
            if(IndexSkins == 4 || IndexSkins == 5)
            {
                heath -= 3;
            }
            else
                heath -= 4;
        }
        if (collision.tag == "Meteor Little")
            heath--;
        if (collision.tag == "Meteor Midle")
        {
            if(IndexSkins == 4 || IndexSkins == 5)
            {
                heath -= 1;
            }
            else
                heath -= 2;
        }
        if (collision.tag == "Mine")
        {
            if(IndexSkins == 5)
            {
                heath -= 3;
            }
            else
                heath -= 4;
        }
        if (collision.tag == "Patron2")
        {
            if (IndexSkins != 0)
                heath--;
            else
                heath -= 2;
        }
           
        if (collision.tag == "IceBoll")
        {
            MovePlayer.time = 5;
            heath--;
        }

        if (collision.tag == "IceMina")
        {
            if (IndexSkins > 2)
            {
                heath -= 3;
            }
            else
            {
                MovePlayer.time = 5;
                heath -= 4;
            }
        }

        if (collision.tag == "Saw")
            heath -= 3;
    }
}
