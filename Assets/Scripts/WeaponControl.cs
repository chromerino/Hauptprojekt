using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponControl : MonoBehaviour
{
    public GameObject[] MainWeapons;
    public GameObject[] SecondaryWeapons;
    public GameObject[] MeleeWeapons;
    private int currentMainWeapon;
    private int currentSecondaryWeapon;
    private int currentMeleeWeapon;
    private GameObject currentlyEquippedWeapon;
    public Button [] MW;
    public Button[] SW;
    public Button[] BF;
    private int currentBuff;
    private WeaponScript currentWeaponsStats;
    public GameObject ArmorUI;
    public GameObject EquipmentMenu;
    public GameObject World;
    
    void Start()
    {
        EquipmentMenu.SetActive(false);
    } 
   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if(Time.time>= currentWeaponsStats.getBorder())
            {
                if (currentWeaponsStats.type == WeaponScript.WeaponType.Melee)
                {
                    meleeAttack();
                    Debug.Log("POW!!! (Melee-attacking)");
                }
                else
                {
                    if (currentWeaponsStats.ammoInMagazine > 0)
                    {
                        Debug.Log("bumm!!! (shooting)");
                        currentWeaponsStats.ammoInMagazine--;
                    }else if (currentWeaponsStats.currentAmmo > 0)
                    {
                        currentWeaponsStats.reload();
                        currentWeaponsStats.setBorder();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading");
            currentWeaponsStats.reload();
            currentWeaponsStats.setBorder();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("mainweapon equipped!");
            equipMainWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("secondary weapon equipped!");
            equipSecondaryWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("melee-weapon equipped!");
            equipMeleeWeapon();
        }
    }
    public void meleeAttack()
    {

    }
    public void shoot()
    {

    }
    public void vanish()
    {
        EquipmentMenu.SetActive(false);
    }
    public void equipMainWeapon()
    {
        currentlyEquippedWeapon = MainWeapons[currentMainWeapon];
        currentWeaponsStats=currentlyEquippedWeapon.GetComponent<WeaponScript>();
    }
    public void equipSecondaryWeapon()
    {
        currentlyEquippedWeapon = SecondaryWeapons[currentSecondaryWeapon];
        currentWeaponsStats = currentlyEquippedWeapon.GetComponent<WeaponScript>();
    }
    public void equipMeleeWeapon()
    {
        currentlyEquippedWeapon = MeleeWeapons[currentMeleeWeapon];
        currentWeaponsStats = currentlyEquippedWeapon.GetComponent<WeaponScript>();
    }
    public void openMenu()
    {
        EquipmentMenu.SetActive(true);
        World.GetComponent<World>().deactivate_ALIVE_UI();
        World.GetComponent<World>().deactivate_Player();
        MW[currentMainWeapon].onClick.Invoke();
        SW[currentSecondaryWeapon].onClick.Invoke();
        BF[currentBuff].onClick.Invoke();
    }
    
    public void onSpawn()
    {
        
        if (currentBuff == 1)
        {
            MainWeapons[currentMainWeapon].GetComponent<WeaponScript>().moreAmmo();
            SecondaryWeapons[currentSecondaryWeapon].GetComponent<WeaponScript>().moreAmmo();
        }
        else
        {
            MainWeapons[currentMainWeapon].GetComponent<WeaponScript>().resetAmmo();
            SecondaryWeapons[currentSecondaryWeapon].GetComponent<WeaponScript>().resetAmmo();

            if (currentBuff == 2)
            {
                ArmorAndWeapons armor = ArmorUI.GetComponent<ArmorAndWeapons>();
                armor.equipRandomArmorpiece();
            }
            else
            {

            }


        }
        equipMainWeapon();
        vanish();
    }

     public void freeze(Button but)
    {
        but.interactable = false;
    }
    public void unfreeze(Button but)
    {
        but.interactable = true;
    }
    public void unfreeze(Button[] but)
    {
        foreach (Button b in but){
            unfreeze(b);
        }
    }
    public void mw1()
    {
        currentMainWeapon = 0;
        unfreeze(MW);
        freeze(MW[0]);
    }
    public void mw2()
    {
        currentMainWeapon = 1;
        unfreeze(MW);
        freeze(MW[1]);
    }
    public void mw3()
    {
        currentMainWeapon = 2;
        unfreeze(MW);
        freeze(MW[2]);
    }
    public void sw1()
    {
        currentSecondaryWeapon = 0;
        unfreeze(SW);
        freeze(SW[0]);
    }
    public void sw2()
    {
        currentSecondaryWeapon = 1;
        unfreeze(SW);
        freeze(SW[1]);
    }
    public void sw3()
    {
        currentSecondaryWeapon = 2;
        unfreeze(SW);
        freeze(SW[2]);
    }

    public void bf1()
    {
        currentBuff = 0;
        unfreeze(BF);
        freeze(BF[0]);
    }
    public void bf2()
    {
        currentBuff = 1;
        unfreeze(BF);
        freeze(BF[1]);
    }
    public void bf3()
    {
        currentBuff = 2;
        unfreeze(BF);
        freeze(BF[2]);
    }
}
