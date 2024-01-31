using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Shop : MonoBehaviour
{
    public static int[] PriceUpShot = { 15, 50, 90, 150, 220, 330 };//цена улучшения
    int[] PriceUpShot1 =      { 30, 70, 130, 220, 300, 400 };
    int[] PriceUpShot2 =      { 15, 25, 40, 60, 80, 100 };
    public static int[] controllerButtomUp = { 3, 3, 3, 3, 3, 3 };
    public int index = 0;
    public Text TextPriceUpShot;
    public GameObject ButtomUpShot;
    public Text TextButtomUpShot;
    public GameObject[] SpaceShip = new GameObject [5]; //Картинки
    public GameObject[] BackAndForward;
    int[] priceSpaceShip1 = { 0, 90, 190, 330, 160, 210 };
    public static int[] GiveSpaceShip = { 1, 0, 0, 0, 0, 0 }; //Наличие космолетов
    public GameObject ButtomSelect;
    public GameObject ButtomBuy;
    public GameObject TextSelect;
    public GameObject TextBuy;
    public GameObject ButtomSelectActive;
    public GameObject TextPrice;
    public GameObject ImageCoin;
    public GameObject ImageCrystal;
    public GameObject[] MyMany;
    public GameObject[] ElementUpShot;
    public GameObject[] TextDamageObject;
    public AudioSource AudioSourceBuy;
    public AudioSource AudiSourceUpShot;
    public AudioSource AudioSourceOnClik;
    GameObject MainCameraMeny;


    public void SaveSpaceShip()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt($"SpaceShip_{i}", GiveSpaceShip[i]);
        }
        PlayerPrefs.SetInt("ScoreCoin", Game.ScoreCoin);
        PlayerPrefs.SetInt("ScoreCristal", Game.ScoreCrystal);
    }

    public void SavePriceUpShot()
    {
       
        for(int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt($"PriceUpShot_{i}", PriceUpShot[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt($"controllerButtomUp_{i}", controllerButtomUp[i]);
        }
        for(int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetFloat($"TimeShot_{i}", Shot.TimeShot[i]);
        }
        PlayerPrefs.SetInt("ScoreCoin", Game.ScoreCoin);
        PlayerPrefs.SetInt("ScoreCristal", Game.ScoreCrystal);
    }

    private void FixedUpdate()
    {
        MyMany[0].GetComponent<Text>().text = Game.ScoreCoin.ToString();
        MyMany[1].GetComponent<Text>().text = Game.ScoreCrystal.ToString();
    }

    private void Start()
    {

        MainCameraMeny = GameObject.Find("Main Camera Meny");
        Destroy(MainCameraMeny, 1f);
        WatchPriceUpShot();
        //Доступ к нопке улучшить
        
        if (controllerButtomUp[index] == 0)
            ButtomUpShot.SetActive(false);
        if (controllerButtomUp[index] != 0 && GiveSpaceShip[index] == 1)
        {
            ButtomUpShot.SetActive(true);
            if (controllerButtomUp[index] > 1)
            {
                if (Game.ScoreCoin >= PriceUpShot[index])
                {
                    ButtomUpShot.GetComponent<Button>().enabled = true;
                    ButtomUpShot.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
                }
                else
                {
                    ButtomUpShot.GetComponent<Button>().enabled = false;
                    ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
                }
            }
            if (controllerButtomUp[index] == 1)
            {
                if (Game.ScoreCrystal >= PriceUpShot[index])
                {
                    ButtomUpShot.GetComponent<Button>().enabled = true;
                    ButtomUpShot.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
                }
                else
                {
                    ButtomUpShot.GetComponent<Button>().enabled = false;
                    ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
                }
            }
        }
        else
            ButtomUpShot.SetActive(false);
        TextPriceUpShot.text = "Скорость стрельбы: " + Shot.TimeShot[index].ToString();

        MyMany[0].GetComponent<Text>().text = Game.ScoreCoin.ToString();
        MyMany[1].GetComponent<Text>().text = Game.ScoreCrystal.ToString();
        //Вкл и выкл кнопки выбор
        if (CollisionPlayer.IndexSkins == index)
        {
            ButtomSelect.SetActive(false);
            ButtomSelectActive.SetActive(true);
        }
        else
        {
            ButtomSelect.SetActive(true);
            ButtomSelectActive.SetActive(false);
        }
        //Вкл и вкл кнопки купить
        if(GiveSpaceShip[index] == 1)
        {
            ButtomBuy.SetActive(false);
        }
        else
        {
            ButtomBuy.SetActive(true);
        }
    }


    public void FalseInfoBox()
    {
        TextDamageObject[10].SetActive(false);
    }

    public void OnClickInfo()
    {
       for(int i = 0; i < 10; i++)
        {
            TextDamageObject[i].GetComponent<Text>().text = CollisionPlayer.DamageSpace_0[index, i].ToString();
        }
        TextDamageObject[10].SetActive(!TextDamageObject[10].activeSelf);
    }

    public void WatchPriceUpShot()
    {
        ElementUpShot[2].GetComponent<Text>().text = PriceUpShot[index].ToString();
        if(GiveSpaceShip[index] == 1 && controllerButtomUp[index] != 0)
        {
            if (controllerButtomUp[index] > 1)
            {
                ElementUpShot[0].SetActive(true);
                ElementUpShot[1].SetActive(false);
            }

            else
            {
                ElementUpShot[0].SetActive(false);
                ElementUpShot[1].SetActive(true);
            }

            ElementUpShot[2].SetActive(true);
        }
        else
        {
            ElementUpShot[0].SetActive(false);
            ElementUpShot[1].SetActive(false);
            ElementUpShot[2].SetActive(false);
        }
    }

    public void OnClickUpShot()
    {
        AudiSourceUpShot.Play();
        Shot.TimeShot[index] -= 0.1f;
        //Определение кристаллы или монеты
        if(controllerButtomUp[index] > 1)
        {
            Game.ScoreCoin -= PriceUpShot[index];
        }
        else
        {
            Game.ScoreCrystal -= PriceUpShot[index];
        }

        controllerButtomUp[index] -= 1;

        //Определение цены
        if (controllerButtomUp[index] == 2)
            PriceUpShot[index] = PriceUpShot1[index];
        if (controllerButtomUp[index] == 1)
            PriceUpShot[index] = PriceUpShot2[index];

        if (Shot.TimeShot[index] == 0.6999999f)
        {
            TextPriceUpShot.text = "Скорость стрельбы: " + (Shot.TimeShot[index] += 0.0000001f).ToString();
        }
        else
            TextPriceUpShot.text = "Скорость стрельбы: " + Shot.TimeShot[index].ToString();

        if (controllerButtomUp[index] == 1 && Game.ScoreCrystal < PriceUpShot[index])
        {
            ButtomUpShot.GetComponent<Button>().enabled = false;
            ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
            TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
        }

        if(controllerButtomUp[index] > 1 && Game.ScoreCoin < PriceUpShot[index])
        {
            ButtomUpShot.GetComponent<Button>().enabled = false;
            ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
            TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
        }

        MyMany[0].GetComponent<Text>().text = Game.ScoreCoin.ToString();
        MyMany[1].GetComponent<Text>().text = Game.ScoreCrystal.ToString();
        if(controllerButtomUp[index] == 0)
            ButtomUpShot.SetActive(false);
        
    }

    public void ButtomGlavMeny()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtomForward()
    {
        index++;
    }
    
    public void ButtomBack()
    {
        index--;
    }

    public void OnClickSelect()
    {
        CollisionPlayer.IndexSkins = index;
        ButtomSelectActive.SetActive(true);
        ButtomSelect.SetActive(false);
        //Сохранение выбора
        PlayerPrefs.SetInt("IndexSkins", CollisionPlayer.IndexSkins);
    }

    public void OnClickBuy()
    {
        AudioSourceBuy.Play();
        ImageCrystal.SetActive(false);
        if (index < 4)
            Game.ScoreCoin -= priceSpaceShip1[index];

        else
            Game.ScoreCrystal -= priceSpaceShip1[index];

        ImageCoin.SetActive(false);
        TextPrice.SetActive(false);
        ButtomSelect.GetComponent<Button>().enabled = true;
        GiveSpaceShip[index] = 1;
        ButtomSelect.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
        TextSelect.GetComponent<Text>().color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
        ButtomBuy.SetActive(false);
        MyMany[0].GetComponent<Text>().text = Game.ScoreCoin.ToString();
        MyMany[1].GetComponent<Text>().text = Game.ScoreCrystal.ToString();

        //Доступ к нопке улучшить стрельбу
        if(controllerButtomUp[index] == 0)
            ButtomUpShot.SetActive(false);
        if (controllerButtomUp[index] != 0 && GiveSpaceShip[index] == 1)
        {
            ButtomUpShot.SetActive(true);
            if (controllerButtomUp[index] > 1)
            {
                if (Game.ScoreCoin >= PriceUpShot[index])
                {
                    ButtomUpShot.GetComponent<Button>().enabled = true;
                    ButtomUpShot.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
                }
                else
                {
                    ButtomUpShot.GetComponent<Button>().enabled = false;
                    ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
                }
            }
            if (controllerButtomUp[index] == 1)
            {
                if (Game.ScoreCrystal >= PriceUpShot[index])
                {
                    ButtomUpShot.GetComponent<Button>().enabled = true;
                    ButtomUpShot.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
                }
                else
                {
                    ButtomUpShot.GetComponent<Button>().enabled = false;
                    ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
                }
            }
        }
        else
            ButtomUpShot.SetActive(false);
    }

    public void ToWatchSpaceShip()
    {
        //Доступ к нопке улучшить стрельбу
        if (controllerButtomUp[index] != 0 && GiveSpaceShip[index] == 1)
        {
            ButtomUpShot.SetActive(true);
            if (controllerButtomUp[index] > 1)
            {
                if (Game.ScoreCoin >= PriceUpShot[index])
                {
                    ButtomUpShot.GetComponent<Button>().enabled = true;
                    ButtomUpShot.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
                }
                else
                {
                    ButtomUpShot.GetComponent<Button>().enabled = false;
                    ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
                }
            }
            if(controllerButtomUp[index] == 1)
            {
                if(Game.ScoreCrystal >= PriceUpShot[index])
                {
                    ButtomUpShot.GetComponent<Button>().enabled = true;
                    ButtomUpShot.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
                }
                else
                {
                    ButtomUpShot.GetComponent<Button>().enabled = false;
                    ButtomUpShot.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
                    TextButtomUpShot.color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
                }
            }
        }
        else
            ButtomUpShot.SetActive(false);

        TextPriceUpShot.text = "Скорость стрельбы: " + Shot.TimeShot[index].ToString();
        TextPrice.GetComponent<Text>().text = priceSpaceShip1[index].ToString();
        //Доступ к нопке купить
        if ((Game.ScoreCoin >= priceSpaceShip1[index] && GiveSpaceShip[index] != 1 && index < 4) || 
            (index > 3 && Game.ScoreCrystal >= priceSpaceShip1[index]))
        {
            ButtomBuy.GetComponent<Button>().enabled = true;
            ButtomBuy.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
            TextBuy.GetComponent<Text>().color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
        }
        else
        {
            ButtomBuy.GetComponent<Button>().enabled = false;
            ButtomBuy.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
            TextBuy.GetComponent<Text>().color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
        }

        if (GiveSpaceShip[index] == 1)
            ButtomBuy.SetActive(false);

        //Вкл и выкл кнопки выбор
        if (CollisionPlayer.IndexSkins == index)
        {
            ButtomSelect.SetActive(false);
            ButtomSelectActive.SetActive(true);
        }
        else
        {
            ButtomSelect.SetActive(true);
            ButtomSelectActive.SetActive(false);
        }

        // Доступ кнопки выбор, если космолет куплен
        if (GiveSpaceShip[index] == 1)
        {
            ImageCoin.SetActive(false);
            ImageCrystal.SetActive(false);
            TextPrice.SetActive(false);
            ButtomBuy.SetActive(false);
            ButtomSelect.GetComponent<Button>().enabled = true;
            ButtomSelect.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 117 / 255.0f, 1);
            TextSelect.GetComponent<Text>().color = new Color(242 / 255.0f, 71 / 255.0f, 71 / 255.0f, 1);
        }
        else
        {
            //Смена монеты на кристал где цена
            if (index >= 4)
            {
                ImageCoin.SetActive(false);
                ImageCrystal.SetActive(true);
            }
            else
            {
                ImageCoin.SetActive(true);
                ImageCrystal.SetActive(false);
            }
            //
            TextPrice.SetActive(true);
            ButtomBuy.SetActive(true);
            ButtomSelect.GetComponent<Button>().enabled = false;
            ButtomSelect.GetComponent<Image>().color = new Color(174 / 255.0f, 174 / 255.0f, 174 / 255.0f, 1);
            TextSelect.GetComponent<Text>().color = new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, 1);
        }

        //Отключение кнопок вперед и назад
        if (index == 5)
            BackAndForward[1].SetActive(false);
        else
            BackAndForward[1].SetActive(true);

        if (index == 0)
            BackAndForward[0].SetActive(false);
        else
            BackAndForward[0].SetActive(true);

        // Контролирование выхода за индекс массива
        if (index == SpaceShip.Length)
            index = SpaceShip.Length - 1;
        if (index < 0)
            index = 0;

        // Включение нужного скина
        foreach(GameObject element in SpaceShip)
        {
            element.SetActive(false);
        }

        SpaceShip[index].SetActive(true);
    }

   
}
