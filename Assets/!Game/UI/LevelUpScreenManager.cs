using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScreenManager : MonoBehaviour
{
    [SerializeField] GameObject levelUpCanvasObject;

    public List<UpgradeData> upgradeDataList;
    public List<UpgradeData> unlockedUpgradesList;


    public List<UpgradeButton> upgradeButtonList;


    PauseManager pauseManager;





    private void Start()
    {
        pauseManager = transform.parent.GetComponentInChildren<PauseManager>();

    }






    public List<UpgradeData> GetRandomUpgrades(int count)
    {
        List<UpgradeData> upgradesList = new List<UpgradeData>();

        if (count > upgradeDataList.Count)
        {
            count = upgradeDataList.Count;
        }


        for (int i = 0; i < count; i++)
        {
            upgradesList.Add(upgradeDataList[Random.Range(0, upgradeDataList.Count)]);
        }
        return upgradesList;
    }



    public void ContinuePressed()
    {
        pauseManager.ContiniueGame();
        levelUpCanvasObject.SetActive(false);
    }

    public void OpenLevelUpScreen()
    {
        levelUpCanvasObject.SetActive(true);
        SetupButtons();
        pauseManager.ContiniueGame();
        
    }


    private void SetupButtons()
    {
        //// MAKE IT BETTER
        if(upgradeDataList.Count == 0)
        {
            foreach(UpgradeButton button in upgradeButtonList)
            {
                button.Set(upgradeDataList[0]);
            }
        }
        for (int i = 1; i < upgradeDataList.Count + 1; i++)
        {
            upgradeButtonList[i - 1].Set(upgradeDataList[i - 1]);
        }
    }








    
}
