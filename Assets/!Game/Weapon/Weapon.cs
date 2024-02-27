using UnityEngine;

public class Weapon
{
    public string name;
    public int magSize;
    public int currentBullets;
    
    public int maxAmmo;
    public int currentAmmo;


    [SerializeField] public GameObject bulletPrefab;



    public virtual void Shoot()
    {
        
    }
}



public class Pistol : Weapon
{



    public override void Shoot()
    {

    }
}

public class AssaultRifle : Weapon
{



    public override void Shoot()
    {

    }
}



