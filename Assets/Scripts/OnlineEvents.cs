using System.Collections;
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
        evnt.Attacker.gameObject.GetComponent<PlayerStartScript>().PlayWeaponSound(evnt.SoundIndex);

        if (evnt.Target != null || evnt.Target.IsOwner)
        {
            var targetScript = evnt.Target.gameObject.GetComponent<PlayerStartScript>().healthbar.GetComponent<Hearts>();
            targetScript.receiveDMG(evnt.Damage);
        }
        // Sonstige Effekte
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
}
