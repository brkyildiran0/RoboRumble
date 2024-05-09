using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;
    
    private void Awake(){
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevel",1);
        int completedLevels = PlayerPrefs.GetInt("CompletedLevel",0);
        for (int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevels;i++){
            buttons[i].interactable = true;
        }
        for (int i = 0; i < completedLevels;i++){
            Debug.Log("Completed level:" + buttons[i].name);
        }
    }

    public void OpenScene(int textLevel){
        //AudioManager.Instance.PlaySFX("ButtonAt");
        SceneManager.LoadScene("Level "+textLevel.ToString());
        Time.timeScale = 1;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.U)){
            PlayerPrefs.SetInt("UnlockedLevel",PlayerPrefs.GetInt("UnlockedLevel",1)+1);
            Debug.Log("UNLOCKED A LEVEL");
        }
        if (Input.GetKeyDown(KeyCode.D)){
            PlayerPrefs.DeleteAll();
        }

    }


}
