using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private float previousGameSpeed;

    public void PauseGame()
    {
        previousGameSpeed = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void ContiniueGame()
    {
        if(previousGameSpeed != 0f)
        {
            Time.timeScale = previousGameSpeed;
        }
        else{
            Time.timeScale = 1f;
        }
        
    }
}
