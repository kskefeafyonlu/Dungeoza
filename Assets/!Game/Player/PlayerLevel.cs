using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
   
    float exp = 0f;
    float expThreshold = 10f;
    int level = 1;
    Slider expSlider;
    TextMeshProUGUI levelText;
    TextMeshProUGUI expText;


    private GameObject levelUpObject;

    
    public List<UpgradeData> upgradesAchieved = new List<UpgradeData>();


    private void Start() 
    {
        levelUpObject = GameObject.Find("LevelScreenManager");

        levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        expText = GameObject.Find("ExpText").GetComponent<TextMeshProUGUI>();
        expSlider = GameObject.Find("ExpSlider").GetComponent<Slider>();

        UpdateUI();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AddExp(10f);
        }
    }
    





    public void AddExp(float amount)
    {
        exp += amount;
        CheckLevelUpAvailability();
        UpdateUI();
    }

    private void CheckLevelUpAvailability()
    {
        if (exp >= expThreshold)
        {
            float tempExp = exp - expThreshold;
            exp = tempExp;
            expThreshold = expThreshold * 1.5f;
            level++;
            levelUpObject.GetComponent<LevelUpScreenManager>().OpenLevelUpScreen();
            

        }
    }

    private void UpdateUI()
    {
        expSlider.value = exp/expThreshold;
        levelText.text = $"{level}";
        expText.text = $"{exp} / {expThreshold}";
    }




    
}
