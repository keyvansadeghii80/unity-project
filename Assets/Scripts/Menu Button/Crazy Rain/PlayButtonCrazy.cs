using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonCrazy : MonoBehaviour
{
    public void goToNextScene()
    {
        SceneManager.LoadScene("rain");
    }
}
