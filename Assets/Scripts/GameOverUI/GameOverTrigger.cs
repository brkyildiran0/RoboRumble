using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameOverManager gameOverManager;
    void OnTriggerEnter(){
        gameOverManager.WinLevel();
    }
}
