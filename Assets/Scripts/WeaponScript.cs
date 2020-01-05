using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public double Damage;
    public double fireCD; //cooldown between shots/attacks (can also  be a knife or another melee weapon)
    enum WeaponType {Primary, Secundary, Melee }
    public int magazineSize; //only important if non-melee weapon
    public int ammoInMagazine;
    public int ammoMax; //maximum ammunation possible : only important if non-melee weapon
    public int currentAmmo;
    public double reloadTime; //only important if non-melee weapon
    public double timeBorder;



    public void loadBullets(int numberOfBullets)
    {
        if (numberOfBullets > currentAmmo)
        {
            numberOfBullets = currentAmmo;
        }
        if (numberOfBullets+ ammoInMagazine > magazineSize)
        {
            numberOfBullets = magazineSize-ammoInMagazine;
        }
        currentAmmo -= numberOfBullets;
        ammoInMagazine += numberOfBullets;

    }
    public void ResetAmmo()
    {
        currentAmmo = ammoMax;
        ammoInMagazine = magazineSize;
    }
    public void MoreAmmo()
    {
        currentAmmo = ammoMax+2*magazineSize;
        ammoInMagazine = magazineSize;
    }
}
