using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoSelecLevel (){
        SceneManager.LoadScene("LevelSelection");
    }
    public void GoSettings (){
        SceneManager.LoadScene("Settings");
    }

    public void GoMainMenu (){
        SceneManager.LoadScene("MainMenu");
    }

    public void GoQuit (){
        Application.Quit();
    }
}
