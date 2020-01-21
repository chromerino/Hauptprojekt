
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : Bolt.EntityBehaviour<IPlayerState>

{

	//public TMPro.TextMeshProUGUI myScore;
	public TMPro.TextMeshProUGUI myKill;
	public TMPro.TextMeshProUGUI myDeath;
    public TMPro.TextMeshProUGUI myPlayer;
    public TMPro.TextMeshProUGUI theirPlayer;
    //public TMPro.TextMeshProUGUI theirScore;
	public TMPro.TextMeshProUGUI theirKill;
	public TMPro.TextMeshProUGUI theirDeath;

	GameObject opponent;

	override public void Attached()
	{

		state.kills = 0;
		state.deaths = 0;

        RefreshScore();
		this.gameObject.SetActive(false);

	}

	override public void SimulateOwner()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			this.gameObject.SetActive(true);
		}


		if (Input.GetKeyUp(KeyCode.Tab))
		{
			this.gameObject.SetActive(false);
		}

		//TODO: if(killed enemy)
		//unkommentieren hier
		//state.kills += 1;
		//RefreshScore();

		//TODO: if(get killed by enemy)
		//unkommentieren hier
		//state.deaths += 1;
		//RefreshScore();
	}


	void RefreshScore()
	{
		//myScore.text = (state.kills * 1).ToString();
		myKill.text = (state.kills).ToString();
		myDeath.text = (state.deaths).ToString();

		//theirScore.text = (state.deaths * 1).ToString();
		theirKill.text = (state.deaths).ToString();
		theirDeath.text = (state.kills).ToString();

	}
}
