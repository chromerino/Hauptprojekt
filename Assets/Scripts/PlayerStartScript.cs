using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStartScript : Bolt.EntityBehaviour<IPlayerState>
{
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject UI_Canvas;
    public GameObject healthbar;
    public FirstPersonController fps;
    
    public override void Attached()
    {
        if(!entity.IsOwner)
        {
            Destroy(world);
            Destroy(UI_Canvas);
        }
    }
}
