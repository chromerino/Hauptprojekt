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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void equipMainWeapon()
    {
        currentlyEquippedWeapon = MainWeapons[currentMainWeapon];
    }
    public void equipSecondaryWeapon()
    {
        currentlyEquippedWeapon = SecondaryWeapons[currentSecondaryWeapon];
    }
    public void equipMeleeWeapon()
    {
        currentlyEquippedWeapon = MeleeWeapons[currentMeleeWeapon];
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
