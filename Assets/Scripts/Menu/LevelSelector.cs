using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public Text textLevel;

    // Start is called before the first frame update
    void Start()
    {
        textLevel.text = level.ToString();
        
    }

    public void OpenScene(){
        //AudioManager.Instance.PlaySFX("ButtonAt");
        SceneManager.LoadScene("Level "+level.ToString());
    }
}
