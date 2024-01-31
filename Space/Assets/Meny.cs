using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meny : MonoBehaviour
{
    public GameObject ShopCamera;
    public GameObject GameCamera;
    public AudioSource audioSourceClick;

    private void Start()
    {
        GiveSave();

        ShopCamera = GameObject.Find("Main Camera Shop");
        Destroy(ShopCamera, 1f);
        GameCamera = GameObject.Find("Main Camera Game");
        Destroy(GameCamera, 1f);
    }

    public void audioSourceOnClick()
    {
        DontDestroyOnLoad(audioSourceClick);
        audioSourceClick.Play();
    }

    public void OnClickStartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickShop()
    {
        SceneManager.LoadScene(2);
    }

    public void GiveSave()
    {
        //Загрузка наличия космрлета
        for(int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.HasKey($"SpaceShip_{i}"))
                Shop.GiveSpaceShip[i] = PlayerPrefs.GetInt($"SpaceShip_{i}");
        }
        //Загрузка цены улучшения
        for(int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.HasKey($"PriceUpShot_{i}"))
                Shop.PriceUpShot[i] = PlayerPrefs.GetInt($"PriceUpShot_{i}");
        }
        //Загрузка контроллера кнопки улучшения(выбор цены улучшения)
        for(int i = 0; i < 6; i++)
        {
            if(PlayerPrefs.HasKey($"controllerButtomUp_{i}"))
                Shop.controllerButtomUp[i] = PlayerPrefs.GetInt($"controllerButtomUp_{i}");
        }
        //Загрузка скорости стрельбы
        for (int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.HasKey($"TimeShot_{i}"))
                Shot.TimeShot[i] = PlayerPrefs.GetFloat($"TimeShot_{i}");
        }
        //Загрузка монет и кристалов
        if(PlayerPrefs.HasKey("ScoreCoin"))
            Game.ScoreCoin = PlayerPrefs.GetInt("ScoreCoin");
        if(PlayerPrefs.HasKey("ScoreCristal"))
            Game.ScoreCrystal = PlayerPrefs.GetInt("ScoreCristal");
        //Загрузка выбора
        if (PlayerPrefs.HasKey("IndexSkins"))
            CollisionPlayer.IndexSkins = PlayerPrefs.GetInt("IndexSkins");
        //Каждые 3 проигрыша вкл реклама
        if(PlayerPrefs.HasKey("ControllerThree"))
            Game.ControllerThree = PlayerPrefs.GetInt("ControllerThree");
    }
}
