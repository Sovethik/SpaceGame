using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int Score = 0;

    private void Start()
    {
        StartCoroutine(Render());
    }

    IEnumerator Render ()
    {
        while(!Game.lose)
        {
            if (SpawnEnemy.TimeIce > 0 && SpawnEnemy.TimeAlien > 0)
            {
                Score += 1;
                GetComponent<Text>().text = "Ñ÷¸ò: " + Score.ToString();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
