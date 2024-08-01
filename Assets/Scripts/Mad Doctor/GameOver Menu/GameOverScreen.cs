using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{  
    public Text pointsText;
    
    public void Setup()
    {  
       gameObject.SetActive(true);
       pointsText.text = TagManager.Count + "  POINTS";
    }
   
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;
    }
   

}
