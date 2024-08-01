using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    private GameOverScreen g;

    [SerializeField]
    private Text enemyKillCountTxt;

    public  int enemyKillCount;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        TagManager.Count++;
        enemyKillCountTxt.text = "Enemies Killed:" + enemyKillCount;     
    }
   
    public void RestartGame()
    {
        Invoke("Restart", 3f);
    }

    //void Restart()
   // {
       // UnityEngine.SceneManagment.SceneManager.LoadScene("Gameplay");
   // }
}
