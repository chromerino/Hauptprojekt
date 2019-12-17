using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAndWeapons : MonoBehaviour
{public GameObject[] Armor;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<4; i++){
		Armor[i].SetActive(false);
		}
    }

    public void equipItem(int i){
	Armor[i].SetActive(true);
	}
	public void deequipItem(int i){
	Armor[i].SetActive(false);
	}

}
