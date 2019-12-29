using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeverEventListener : Bolt.GlobalEventListener
{
	public bool hitting;
	bool oneSecCounter;
	int timer = 0;

	// every axe swing opens a 1s time window. in this 1s, if axe in body, would count it as a hit.
	public override void OnEvent(HitEvent evnt)
	{
		//evnt.HittingBool = true;
		//// react to axe swing only when not counting
		//if (!hitting && !oneSecCounter) 
		//{ 
		//	hitting = true;
		//	oneSecCounter = true;
		//}
	}

	private void FixedUpdate()
	{
		//if (oneSecCounter) 
		//{
		//	if (timer <= 50)
		//	{
		//		timer++;
		//	}
		//	// 1 sec is over
		//	else
		//	{
		//		oneSecCounter = false;
		//		hitting = false;
		//		timer = 0;
		//	}
		//}
		
	}
}
