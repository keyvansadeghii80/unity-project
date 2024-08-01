using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenRain : MonoBehaviour
{
    public Text pointsText;

    public void Setup()
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: "+ Helper.Score;
    }

    public void RestartButton()
    {
        Helper.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;
    }
}
