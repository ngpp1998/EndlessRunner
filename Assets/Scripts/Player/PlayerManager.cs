using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public GameObject redPotText;
    public GameObject greenPotText;
    public GameObject controlsText;
    public GameObject rulesText;
    public static int numberOfCoins;
    public Text coinsText;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0; //freezes the game
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "COINS: " + numberOfCoins; //list the number of coins collected
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
            Destroy(redPotText);
            Destroy(greenPotText);
            Destroy(controlsText);
            Destroy(rulesText);
        }
    }
}
