using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    bool gameHasEnd = false;
    public float restartDelay = 1f;
    public GameObject winLevelUI;
    public bool GameIsPaused = false;

    public void GameOver(){
        if(gameHasEnd == false){
            gameHasEnd = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void WinLevel(){
        winLevelUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
