using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScreen : MonoBehaviour
{
    private GameObject levelUpCanvasObject;

    private void Start() 
    {
        levelUpCanvasObject = GameObject.Find("LevelUpCanvas");
    }




    


    public void ContinuePressed()
    {
        Time.timeScale = 1f;
        levelUpCanvasObject.SetActive(true);
    }
}
