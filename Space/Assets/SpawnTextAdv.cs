using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTextAdv : MonoBehaviour
{
    public static bool Spawn = false;
    public GameObject TextAdvNot;

    private void Update()
    {
        if (Spawn)
        {
            Instantiate(TextAdvNot, new Vector2(0, 0), Quaternion.Euler(new Vector2(0, 0)));
            Spawn = false;
        }
    }
}
