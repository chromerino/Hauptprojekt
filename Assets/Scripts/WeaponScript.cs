using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
<<<<<<< HEAD
    public float Damage;
    public bool automatic;
    public float fireCD; //cooldown between shots/attacks (can also  be a knife or another melee weapon)
    public enum WeaponType {Primary, Secundary, Melee };
=======
    public double Damage;
    public double fireCD; //cooldown between shots/attacks (can also  be a knife or another melee weapon)
    public enum WeaponType {Primary, Secondary, Melee };
>>>>>>> Model-testing
    public WeaponType type;
    public int magazineSize; //only important if non-melee weapon
    public int ammoInMagazine;
    public int ammoMax; //maximum ammunation possible : only important if non-melee weapon
    public int currentAmmo;
    public float reloadTime; //only important if non-melee weapon
    public float timeBorder;
    public float sideRecoilLimit;
    public float upRecoilLimit;
    public int ShotSoundId;
    public int reloadSoundId; // Acts as sound for missed attack if melee weapon
    

    void Start()
    {
        timeBorder = 0;
    }
    public WeaponType GetWeaponType()
    {
        return type;
    }
    public void reload()
    {
        Debug.Log("Reloading");
        timeBorder = Time.time + reloadTime;
        int numberOfBullets = currentAmmo;
        if (numberOfBullets+ ammoInMagazine > magazineSize)
        {
            numberOfBullets = magazineSize-ammoInMagazine;
        }
        currentAmmo -= numberOfBullets;
        ammoInMagazine += numberOfBullets;
        
    }
    public void resetAmmo()
    {
        currentAmmo = ammoMax;
        ammoInMagazine = magazineSize;
    }
    public void moreAmmo()
    {
        currentAmmo = ammoMax+2*magazineSize;
        ammoInMagazine = magazineSize;
    }
    public float getBorder()
    {
        return timeBorder;
    }
    public void setBorder()
    {
        timeBorder=Time.time+fireCD;
    }

}
