using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public int length = 5;
    public int height = 5;


    public bool hasUpExit = false;
    public bool hasRightExit = false;
    public bool hasDownExit = false;
    public bool hasLeftExit = false;


    private Quaternion rotationAmount = Quaternion.Euler(0, 0, -90);
    


    public void GetRotated()
    {
        List<bool> tempList = new List<bool>
        {
            hasUpExit,
            hasRightExit,
            hasDownExit,
            hasLeftExit
        };

        hasUpExit = tempList[3];
        hasRightExit = tempList[0];
        hasDownExit = tempList[1];
        hasLeftExit = tempList[2];


        transform.rotation = transform.rotation * rotationAmount;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GetRotated();
        }
    }

}