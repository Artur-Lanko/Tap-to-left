using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Text coinsText;
    private void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShopMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
