
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

	public void resetArmor()
	{
		for (int i = 0; i < 4; i++)
		{
			Armor[i].SetActive(false);
		}
	}

	public void equipRandomArmorpiece()
	{
		for (int i = 0; i < 4; i++)
		{
			List<int> freeArmorslots=null;

			if (Armor[i].activeSelf)
            {
				freeArmorslots.Add(i);

            }
            if (freeArmorslots.Count!= 0)
            {
				int r=freeArmorslots.IndexOf(Random.Range(0, freeArmorslots.Count));
				equipItem(r);
			}
		
			
		}
	}

	public int getProtection()
	{
		int prot = 0;
		for (int i = 0; i < 4; i++)
		{


			if (Armor[i].activeSelf)
			{
				prot++;

			}
		}
		return prot;
	}

}
