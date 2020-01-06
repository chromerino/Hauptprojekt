using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Bolt.EntityBehaviour<IPlayerState>
{
	public int localHealth = 10;
	public bool ShowFound;
	SeverEventListener severEventListener;
	bool listenerFound;
	// Start is called before the first frame update

	//Start
	public override void Attached()
	{
		state.health = localHealth;
		state.AddCallback("health", healthCallback);
	}

	private void Update()
	{
		//if (severEventListener == null)
		//{
		//	try
		//	{
		//		severEventListener = GameObject.Find("ServerEventListener").GetComponent<SeverEventListener>();
		//	}
		//	catch (System.Exception exp) { };
		//}
		//else
		//{
		//	listenerFound = true;
		//}
	}


	private void healthCallback()
	{
		localHealth = state.health;


		if (localHealth <= 0)
		{
			//BoltNetwork.Destroy(gameObject);
		}
	}

	public void TakeDamage()
	{
		state.health -= 1;
	}

	private void OnTriggerEnter(Collider other)
	{
	
		// is weapon and is not my own weapon
		if (!other.transform.IsChildOf(transform) && other.CompareTag("Weapon"))
		{
		    if(entity.IsOwner)
				TakeDamage();
		}
	}
}
