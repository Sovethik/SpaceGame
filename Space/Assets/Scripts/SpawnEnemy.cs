using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Enemy;
    float[] pos = {-2.1f, -1.8f, -1.5f, -1.2f, -0.9f, -0.6f, -0.3f, 0, 0.3f, 0.6f, 0.9f, 1.2f, 1.5f, 1.8f, 2.1f};
    public int random;
    float TimeSpawn = 1f;
    public int ControllerSpawn = 100;
    float TimerRainMeteor = 0;
    public static float TimeIce;
    public static float TimeAlien;

    bool ControllerIceBoss = true;
    GameObject IceBoss;

    bool ControllerAlienBoss = true;
    public GameObject AlienBossLive;
    public GameObject AlienBossLive2;

   
    public void Start()
    {
        StartCoroutine(spawn());
        TimeIce = 100;
        TimeAlien = 100;
    }

    private void Update()
    {
        if (TimerRainMeteor > 0)
            TimerRainMeteor -= Time.deltaTime;
        else
            TimerRainMeteor = 0;
    }


    //Регулятор спавна
    public void TimeSpawnFunc()
    {
        if (score.Score >= 100 && score.Score < 350)
            TimeSpawn = 0.9f;
        if (score.Score >= 350 && score.Score < 700)
            TimeSpawn = 0.8f;
        if (score.Score >= 700 && score.Score < 1050)
            TimeSpawn = 0.7f;
        if (score.Score >= 1050 && score.Score < 1400)
            TimeSpawn = 0.6f;
        if (score.Score >= 1400 && score.Score < 1750)
            TimeSpawn = 0.5f;
    }

    IEnumerator spawn()
    {
        while(true)
        {
            //Постоянный спавн
            while (ControllerSpawn <= 991)
            {
                TimeSpawnFunc();

                random = Random.Range(0, 100);
                //0
                if (random <= 3)
                    Instantiate(Enemy[0], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //1
                if (random > 3 && random <= 10)
                    Instantiate(Enemy[1], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //2
                if (random > 10 && random <= 25)
                    Instantiate(Enemy[2], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //3
                if (random > 25 && random <= 45)
                    Instantiate(Enemy[3], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //4
                if (random > 45 && random <= 68)
                    Instantiate(Enemy[4], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //5
                if (random > 68 && random <= 93)
                    Instantiate(Enemy[5], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //6
                if (random == 94)
                    Instantiate(Enemy[6], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //7
                if (random == 95)
                    Instantiate(Enemy[7], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //8
                if (random == 96)
                    Instantiate(Enemy[8], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //9
                if (random == 97)
                    Instantiate(Enemy[9], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //10
                if (random >= 98)
                    Instantiate(Enemy[10], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                ControllerSpawn = Random.Range(0, 1000);

                yield return new WaitForSeconds(TimeSpawn);
            }

            if (ControllerSpawn > 997)
                TimerRainMeteor = 45;

            //Событие метеоритов
            while(TimerRainMeteor > 0)
            {
                random = Random.Range(0, 100);

                //2
                if (random >= 0 && random <= 30)
                    Instantiate(Enemy[2], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //4
                if (random > 30 && random <= 63)
                    Instantiate(Enemy[4], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //5
                if (random > 63 && random <= 97)
                    Instantiate(Enemy[5], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                //10
                if (random >= 96)
                    Instantiate(Enemy[10], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                ControllerSpawn = 100;

                yield return new WaitForSeconds(0.4f);
            }

            //событие лед

            while(ControllerSpawn > 994 && ControllerSpawn <=997)
            {
                if (TimeIce > 0)
                {
                    TimeSpawnFunc();

                    random = Random.Range(0, 100);
                    //0
                    if (random <= 3)
                        Instantiate(Enemy[0], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //4
                    if (random > 69 && random <= 92)
                        Instantiate(Enemy[4], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //6
                    if (random == 93)
                        Instantiate(Enemy[6], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //7
                    if (random == 94)
                        Instantiate(Enemy[7], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //8
                    if (random == 95)
                        Instantiate(Enemy[8], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //9
                    if (random == 96)
                        Instantiate(Enemy[9], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //10
                    if (random >= 97)
                        Instantiate(Enemy[10], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //11
                    if (random > 28 && random <= 49)
                        Instantiate(Enemy[11], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //12
                    if (random > 49 && random <= 69)
                        Instantiate(Enemy[12], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //13
                    if (random > 13 && random <= 28)
                        Instantiate(Enemy[13], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //14
                    if (random > 3 && random <= 13)
                        Instantiate(Enemy[14], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                }

                else {
                    if (ControllerIceBoss)
                    {
                        //IceBoss
                        Instantiate(Enemy[15], new Vector2(0, 6.3f), Quaternion.Euler(new Vector2(0, 0)));
                        ControllerIceBoss = false;
                        IceBoss = GameObject.Find("Ice Boss Heat");
                    }

                    if (IceBoss.GetComponent<IceBoss>().heath <= 0)
                    {
                        ControllerSpawn = 100;
                        TimeIce = 100;
                        ControllerIceBoss = true;
                    }
                }

                TimeIce -= TimeSpawn;
                yield return new WaitForSeconds(TimeSpawn);

            }

            //Событие инопланетное

            while(ControllerSpawn > 991 && ControllerSpawn <= 994)
            {
                if(TimeAlien > 0)
                {
                    TimeSpawnFunc();

                    random = Random.Range(0, 100);

                    //4
                    if (random >= 50 && random <= 70)
                        Instantiate(Enemy[4], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                    //5
                    if (random > 70 && random <= 92)
                        Instantiate(Enemy[5], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                    //6
                    if (random == 93)
                        Instantiate(Enemy[6], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //7
                    if (random == 94)
                        Instantiate(Enemy[7], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //8
                    if (random == 95)
                        Instantiate(Enemy[8], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));
                    //9
                    if (random == 96)
                        Instantiate(Enemy[9], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                    //10
                    if (random >= 97)
                        Instantiate(Enemy[10], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                    //16
                    if (random > 30 && random <= 50)
                        Instantiate(Enemy[16], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                    //17
                    if (random > 5 && random <= 15)
                        Instantiate(Enemy[17], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));

                    //18
                    if (5 >= random)
                        Instantiate(Enemy[18], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector3(0, 0, 180)));

                    //19
                    if (random > 15 && random <= 30)
                        Instantiate(Enemy[19], new Vector2(pos[Random.Range(0, pos.Length)], 6), Quaternion.Euler(new Vector2(0, 0)));


                }

                else
                {
                    //AlenBoss
                    if (ControllerAlienBoss)
                    {
                        Instantiate(Enemy[20], new Vector2(0, 6.3f), Quaternion.Euler(new Vector2(0, 0)));
                        ControllerAlienBoss = false;
                        AlienBossLive = GameObject.Find("alien Boss Left");
                        AlienBossLive2 = GameObject.Find("alien Boss Right");
                    }

                    if(AlienBossLive.GetComponent<AlienBossLive>().heath <= 0 && AlienBossLive2.GetComponent<AlienBossLive>().heath <= 0)
                    {
                        ControllerSpawn = 100;
                        TimeAlien = 100;
                        ControllerAlienBoss = true;
                    }
                }

                TimeAlien -= TimeSpawn;

                yield return new WaitForSeconds(TimeSpawn);
            }    

        }
    }
}
