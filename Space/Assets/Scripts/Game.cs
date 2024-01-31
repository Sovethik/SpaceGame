using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static bool lose = false;
    public GameObject Coin;
    public GameObject Crystal;
    public GameObject SpawnOb;
    public GameObject Boss;
    public static int ScoreCoin = 500;
    public static int ScoreCrystal = 500;
    public static int ControllerThree = 0;

    public GameObject ButtomRestart;
    public GameObject ButtomGlMeny;
    public GameObject ButtomStart;
    GameObject MainCameraMeny;
    public AudioSource audioSourceOnClick;
    public GameObject BossCenterPush;
    bool controller;

    private void Start()
    {
        controller = true;
        MainCameraMeny = GameObject.Find("Main Camera Meny");
        Destroy(MainCameraMeny, 1f);
        lose = false;
    }

    private void FixedUpdate()
    {
        if(lose && controller)
        {
            ControllerThree++;
            PlayerPrefs.SetInt("ControllerThree", ControllerThree);

            if(ControllerThree % 3 == 0)
                AdsCore.ShowAdsVideo("Interstitial_Android");
            controller = false;
            SpawnOb.SetActive(false);
        }

        PlayerPrefs.SetInt("ScoreCoin", ScoreCoin);
        PlayerPrefs.SetInt("ScoreCristal", ScoreCrystal);

        Coin.GetComponent<Text>().text = ScoreCoin.ToString();
        Crystal.GetComponent<Text>().text = ScoreCrystal.ToString();

        //Спавн босса
        if(score.Score > 1750)
        {
            if (!(Boss == null))
            {
                if(BossCenterPush.GetComponent<BossPushCenter>().heath > 0)
                    SpawnOb.SetActive(false);
                Boss.SetActive(true);
            }
        }
    }

    //Рестарт
    public void OnClickRestart()
    {
        Time.timeScale = 1;
        Shot.timer = 0;
        CollisionPlayer.heath = 5;
        lose = false;
        score.Score = 0;
        Debug.Log(ControllerThree);
        SceneManager.LoadScene(1);
    }

    //Меню
    public void OnClickMeny()
    {
        Time.timeScale = 0;
        ButtomRestart.SetActive(true);
        ButtomGlMeny.SetActive(true);
        ButtomStart.SetActive(true);
    }

    //Продолжить
    public void OnClickStartGame()
    {
        Time.timeScale = 1;
        ButtomRestart.SetActive(false);
        ButtomGlMeny.SetActive(false);
        ButtomStart.SetActive(false);
        audioSourceOnClick.Play();
    }

    //Главное меню

    public void OnClickGlavMeny()
    {
        Time.timeScale = 1;
        audioSourceOnClick.Play();
        SceneManager.LoadScene(0);
    }

}
