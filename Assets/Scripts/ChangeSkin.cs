using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{
    public Skin[] info;
    private bool[] StockCheck;

    public Button buyBtn;
    public Text priceText;
    public Text coinsText;
    public Transform player;
    public int index;

    public int coins;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coins");
        index = PlayerPrefs.GetInt("chosenSkin");
        coinsText.text = coins.ToString();

        StockCheck = new bool[53];
        if (PlayerPrefs.HasKey("StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");

        else
            StockCheck[0] = true;

        info[index].isChosen = true;

        for (int i = 0; i < info.Length; i++)
        {
            info[i].inStock = StockCheck[i];
            if (i == index)
                player.GetChild(i).gameObject.SetActive(true);
            else
                player.GetChild(i).gameObject.SetActive(false);
        }

        priceText.text = "CHOSEN";
        buyBtn.interactable = false;
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArray", StockCheck);
    }

    public void ScrollRight()
    {
        if (index < player.childCount)
        {
            index++;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "CHOSEN";
                buyBtn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBtn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "CHOOSE";
                buyBtn.interactable = true;
            }

            for (int i = 0; i < player.childCount; i++)
                player.GetChild(i).gameObject.SetActive(false);
         

            player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "CHOSEN";
                buyBtn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBtn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "CHOOSE";
                buyBtn.interactable = true;
            }

            for (int i = 0; i < player.childCount; i++)
                player.GetChild(i).gameObject.SetActive(false);

            player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void BuyButtonAction()
    {
        if (buyBtn.interactable && !info[index].inStock)
        {
            if (coins > int.Parse(priceText.text))
            {
                coins -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheck[index] = true;
                info[index].inStock = true;
                priceText.text = "CHOOSE";
                Save();
            }
        }

        if (buyBtn.interactable && !info[index].isChosen && info[index].inStock)
        {
            PlayerPrefs.SetInt("chosenSkin", index);
            buyBtn.interactable = false;
            priceText.text = "CHOSEN";
        }
    }
}

[System.Serializable]
public class Skin
{
    public int cost;
    public bool inStock;
    public bool isChosen;
}