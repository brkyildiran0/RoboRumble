using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public GameObject level;
    public string levelName;
    public Text levelText;
    void Start (){
        levelText.text = levelName;
    }

    public void OpenScene(){
        //AudioManager.Instance.PlaySFX("ButtonAt");
        SceneManager.LoadScene("Level "+levelName);
        Time.timeScale = 1;
    }
}
