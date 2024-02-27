using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
   
    float exp = 0f;
    float expThreshold = 100f;
    int level = 1;
    Slider expSlider;
    TextMeshProUGUI levelText;
    TextMeshProUGUI expText;


    private GameObject levelUpCanvasObject;
    



    private void Start() 
    {
        levelUpCanvasObject = GameObject.Find("LevelUpCanvas");

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
            OpenLevelUpScreen();

        }
    }

    private void UpdateUI()
    {
        expSlider.value = exp/expThreshold;
        levelText.text = $"{level}";
        expText.text = $"{exp} / {expThreshold}";
    }




    private void OpenLevelUpScreen()
    {
        levelUpCanvasObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
