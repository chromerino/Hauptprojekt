using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (evnt.Target.IsOwner)
        {
            var targetScript = evnt.Target.gameObject.GetComponent<PlayerStartScript>().healthbar.GetComponent<Hearts>();
            targetScript.receiveDMG(evnt.Damage);
        }
        // Sonstige Effekte
    }
}
