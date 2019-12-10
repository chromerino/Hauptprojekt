using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineEvents : Bolt.GlobalEventListener
{
    private static int seed = Random.Range(0,5000)*Random.Range(0,5000);
    public override void Connected(BoltConnection connection)
    {
        var evnt = ShareSeedEvent.Create(connection);
        evnt.seed = seed;
    }
    public override void OnEvent (ShareSeedEvent evnt)
    {
        Noise.seed = evnt.seed;
    }
}
