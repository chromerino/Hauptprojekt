﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[BoltGlobalBehaviour]
public class OnlineEvents : Bolt.GlobalEventListener
{
    private static int seed = -1;

    public override void Connected(BoltConnection connection)
    {
        seed = Noise.seed;
        if (seed < 0)
        {
            seed = Random.Range(0, 5000) * Random.Range(0, 5000);
        }
        var evnt = ShareSeedEvent.Create(connection);
        evnt.seed = seed;
        evnt.Send();
    }

    public override void OnEvent (ShareSeedEvent evnt)
    {
        Noise.seed = evnt.seed;
    }

    public override void OnEvent(Attack evnt)
    {
        var attackerScript = evnt.Attacker.gameObject.GetComponent<PlayerStartScript>();
        attackerScript.PlayWeaponSound(evnt.SoundIndex);

        if (evnt.Target != null || evnt.Target.IsOwner)
        {
            var targetScript = evnt.Target.gameObject.GetComponent<PlayerStartScript>().healthbar.GetComponent<Hearts>();
            bool died = targetScript.receiveDMG(evnt.Damage, attackerScript.PlayerCharacter.transform.position);
            if (died)
            {
                evnt.Attacker.GetState<IPlayerState>().kills++;
            }
        }
        // Sonstige Effekte

        if(evnt.Target != null) Debug.Log(evnt.Attacker.GetState<IPlayerState>().name + " hat " + evnt.Target.GetState<IPlayerState>().name + " angegriffen");
    }

    public override void OnEvent(FootStepSound evnt)
    {
        if (evnt.Player.IsOwner) return;
        var script = evnt.Player.gameObject.GetComponent<PlayerStartScript>();
        script.PlayFootstepSound();
    }

    public override void OnEvent(JumpSound evnt)
    {
        if (evnt.Player.IsOwner) return;
        var script = evnt.Player.gameObject.GetComponent<PlayerStartScript>();
        script.PlayJumpSound();
    }

    public override void OnEvent(LandingSound evnt)
    {
        if (evnt.Player.IsOwner) return;
        var script = evnt.Player.gameObject.GetComponent<PlayerStartScript>();
        script.PlayLandingSound();
    }

    public override void OnEvent(PlayerVisibilityChanged evnt)
    {
        var script = evnt.Player.gameObject.GetComponent<PlayerStartScript>();
        script.TogglePlayerVisibility(evnt.Visible);
    }
}
