using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public List<Movability> availableList = new List<Movability>();

    public bool upAvailability = false;
    public bool rightAvailability = false;
    public bool downAvailability = false;
    public bool leftAvailability = false;



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

}

public enum Movability
{
    Up,
    Right,
    Down,
    Left
}

