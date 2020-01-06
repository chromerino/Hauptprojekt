using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartScript : Bolt.EntityBehaviour<IPlayerState>
{
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject UI_Canvas;
    
    public override void Attached()
    {
        if(!entity.IsOwner)
        {
            Destroy(world);
            Destroy(UI_Canvas);
        }
    }
}
