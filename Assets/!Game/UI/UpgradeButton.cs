using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    TextMeshProUGUI text;
    Image icon;
    [SerializeField] private UpgradeData upData;
    PlayerLevel playerLevelScript;
    LevelUpScreenManager levelUpManagerScript;


    private void Awake() 
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        icon = transform.GetChild(1).GetComponent<Image>();
        playerLevelScript = GameObject.FindWithTag("Player").GetComponent<PlayerLevel>();
        levelUpManagerScript = GameObject.Find("LevelScreenManager").GetComponent<LevelUpScreenManager>();
    }


    public void Set(UpgradeData upgradeData)
    {
        upData = upgradeData;
        text.text = upData.upgradeName;
        icon.sprite = upData.upgradeIcon;
    }

    public void SelectedUpgradeButton()
    {
        playerLevelScript.upgradesAchieved.Add(upData);
        levelUpManagerScript.upgradeDataList.Remove(upData);
        levelUpManagerScript.ContinuePressed();

    }


}