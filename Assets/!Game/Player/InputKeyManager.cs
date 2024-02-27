using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyManager : MonoBehaviour
{  
    LevelUpScreenManager levelUpScreenManager;

    private void Awake() {
        levelUpScreenManager = transform.parent.gameObject.GetComponentInChildren<LevelUpScreenManager>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            levelUpScreenManager.OpenLevelUpScreen();
        }
    }
}
