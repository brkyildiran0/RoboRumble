using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    void Update (){
        if (Input.GetKeyDown(KeyCode.Escape)){
            AudioManager.Instance.PlaySFX("ButtonAt");
            if (GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Quit(){
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("LevelSelection");
    }

    public void Restart(){
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Settings(){
        Debug.Log("OPEN SETTINGS PANEL");
    }
}
