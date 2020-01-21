using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponControl : Bolt.EntityBehaviour<IPlayerState>
{
    [SerializeField] private GameObject FirstPersonObject;
    [SerializeField] private GameObject Player;
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

    private float nextPossibleAttack;
    private bool stoppedShooting;
    
    override public void Attached()
    {
        nextPossibleAttack = Time.time;
        EquipmentMenu.SetActive(false);
        stoppedShooting = true;
    } 

    override public void SimulateOwner()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            stoppedShooting = true;
        }

        if (Input.GetKey(KeyCode.Mouse0) && (currentWeaponsStats.automatic || stoppedShooting))
        {
            stoppedShooting = false;
            if (Time.time >= nextPossibleAttack)
            {
                nextPossibleAttack = Time.time + 0.15f;
                if (currentWeaponsStats.type == WeaponScript.WeaponType.Melee)
                {
                    meleeAttack();
                    Debug.Log("POW!!! (Melee-attacking)");
                }
                else
                {
                    if (currentWeaponsStats.ammoInMagazine > 0)
                    {
                        shoot();
                        Debug.Log("bumm!!! (shooting)");
                        Debug.Log("Ammo: "+ currentWeaponsStats.ammoInMagazine+"/"+ currentWeaponsStats.magazineSize);
                        currentWeaponsStats.ammoInMagazine--;
                    }else if (currentWeaponsStats.currentAmmo > 0)
                    {
                        currentWeaponsStats.reload();
                        
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            
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
        GameObject target = GetTarget(3);
        var evnt = Attack.Create(Bolt.GlobalTargets.Others);
        int weaponIndex = currentWeaponsStats.reloadSoundId;

        if (target != null)
        {
            var targetScript = target.GetComponentInParent<PlayerStartScript>();
            if (targetScript != null)
            {
                evnt.Target = targetScript.entity;
                weaponIndex = currentWeaponsStats.ShotSoundId;
            }
        }
        
        evnt.Attacker = entity;
        evnt.Damage = (float)currentWeaponsStats.Damage;

        evnt.SoundIndex = weaponIndex;
        FirstPersonObject.GetComponentInParent<PlayerStartScript>().PlayWeaponSound(weaponIndex);

        evnt.Send();
    }
    public void shoot()
    {
        GameObject target = GetTarget();
        var evnt = Attack.Create(Bolt.GlobalTargets.Others);
        if (target != null)
        {
            var targetScript = target.GetComponentInParent<PlayerStartScript>();
            if (targetScript != null)
            {
                evnt.Target = targetScript.entity;
            }
        }

        evnt.Attacker = entity;
        evnt.Damage = (float)currentWeaponsStats.Damage;

        evnt.SoundIndex = currentWeaponsStats.ShotSoundId;
        FirstPersonObject.GetComponentInParent<PlayerStartScript>().PlayWeaponSound(currentWeaponsStats.ShotSoundId);

        evnt.Send();

        var mouseLook = Player.GetComponent<FirstPersonController>().GetMouseLook();
        mouseLook.SetRecoil(Random.Range(currentWeaponsStats.sideRecoilLimit * -1, currentWeaponsStats.sideRecoilLimit), Random.Range(0.1f, currentWeaponsStats.upRecoilLimit));
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

    private GameObject GetTarget()
    {
        Camera firstPersonCamera = FirstPersonObject.GetComponent<Camera>();
        RaycastHit hit;

        Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit);
        if (hit.collider == null) return null;
        var script = hit.collider.gameObject.GetComponentInParent<PlayerStartScript>();
        if (script == null || script.entity.IsOwner) return null;
        return hit.collider.gameObject;
    }

    private GameObject GetTarget(float range)
    {
        Camera firstPersonCamera = FirstPersonObject.GetComponent<Camera>();
        RaycastHit hit;

        Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range);
        if (hit.collider == null) return null;
        var script = hit.collider.gameObject.GetComponentInParent<PlayerStartScript>();
        if (script == null || script.entity.IsOwner) return null;
        return hit.collider.gameObject;
    }
}
