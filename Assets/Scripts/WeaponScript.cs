﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public double Damage;
    public double fireCD; //cooldown between shots/attacks (can also  be a knife or another melee weapon)
    public enum WeaponType {Primary, Secundary, Melee };
    public WeaponType type;
    public int magazineSize; //only important if non-melee weapon
    public int ammoInMagazine;
    public int ammoMax; //maximum ammunation possible : only important if non-melee weapon
    public int currentAmmo;
    public double reloadTime; //only important if non-melee weapon
    public double timeBorder;
    



    public void reload()
    {
        int numberOfBullets = currentAmmo;
        if (numberOfBullets+ ammoInMagazine > magazineSize)
        {
            numberOfBullets = magazineSize-ammoInMagazine;
        }
        currentAmmo -= numberOfBullets;
        ammoInMagazine += numberOfBullets;
        timeBorder = Time.time + reloadTime;
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
    public double getBorder()
    {
        return timeBorder;
    }
    public void setBorder()
    {
        timeBorder=Time.time+fireCD;
    }

}