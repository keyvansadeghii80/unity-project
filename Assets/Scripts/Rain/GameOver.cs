using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameOverScreenRain g;
    //public Text scoreText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rain")
        {
            //   Debug.Log("game over");
              //scoreText.text = "Game Over";

            
            Destroy(collision.gameObject);
            x();
            

            Time.timeScale = 0;
        }
    }




    public void x()
    {
        //Debug.Log("abas");
        g.Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
