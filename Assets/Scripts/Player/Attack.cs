using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Bolt.EntityBehaviour<IPlayerState>
{
	public GameObject weapon;
	//private HitEvent hitEvnt;

	// Start is called before the first frame update
	public override void Attached()
	{
		state.OnFire = Fire;
		//hitEvnt = HitEvent.Create();

	}

	private void Fire()
	{
		weapon.GetComponent<Animation>().Play();
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0 ) && entity.IsOwner)
		{
			state.Fire();
			//hitEvnt.Send();
		}

	}
}
