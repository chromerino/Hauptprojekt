using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    double Damage;
    double fireCD; //cooldown between shots/attacks (can also  be a knife or another melee weapon)
    enum WeaponType {Primary, Secundary, Melee }
    int magazinSize; //only important if non-melee weapon
    int ammoMax; //maximum ammunation possible : only important if non-melee weapon
    double reloadTime; //only important if non-melee weapon
}
