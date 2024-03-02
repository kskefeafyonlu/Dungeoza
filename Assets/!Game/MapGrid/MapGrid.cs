using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public int length = 5;
    public int height = 5;

""""
   public bool hasUpExit = false;
    public bool hasRightExit = false;
    public bool hasDownExit = false;
    public bool hasLeftExit = false;
""""

    public ArrayList arrlist = new ArrayList(bool hasUpExit, bool hasRightExit, bool hasDownExit, bool hasLeftExit)



    public void GetRotated()
    {
        bool extraExit = false;
        int a = 0;
        foreach (bool i in arrlist)
        {
            if(a==4)
            {
                if(arrlist[0]==true)
            }
            else if (i == true)
            {
                if (arrlist[a + 1] == true) { extraExit = true; }
                i + 1 = true;
            }
            else if (extraExit == true)
            {
                if (arrlist[a + 1] == false) { extraExit = false; }
                i + 1 = true;
            }
            a++;
        }


    }

}