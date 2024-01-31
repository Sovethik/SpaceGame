using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKometRighrt : MonoBehaviour
{
    public GameObject komet;
    private float[] posY = { 4, 5f, 3.5f, 2.5f, 1.5f, 0.5f, -0.5f};
    private int[] SpawnTime = {6, 8, 10, 12, 14 };

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(!Game.lose)
        {
            Instantiate(komet, new Vector2(3, posY[Random.Range(0, posY.Length)]), Quaternion.Euler(new Vector2(0, 0)));

            yield return new WaitForSeconds(SpawnTime[Random.Range(0, SpawnTime.Length)]);
        }
    }
}
