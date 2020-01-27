using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation anim;
    public int mode;

    // Update is called once per frame
    void Update()
    {
        mode = GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().getAnimationMode();
        anim.CrossFade("Idle");
        /*
         * animationMode Legende:
         * 0= no animation
         * 1= stehen mit Primary
         * 2= stehen mit secondary
         * 3= stehen mit Melee
         * 4= laufen mit Primary
         * 5= laufen mit Secondary
         * 6= laufen mit Melee
         * */

        switch (mode)
        {
            case 0:
                anim.CrossFade("Idle");
                break;
            case 1:
                if (anim.IsPlaying("idlewrifle") == false)
                { 
                anim.CrossFade("idlewrifle");
                }
                break;
            case 2:
                if (anim.IsPlaying("idlewpistol") == false)
                {
                    anim.CrossFade("idlewpistol");
                }
                break;
            case 3:
                if (anim.IsPlaying("idlewknife") == false)
                {
                    anim.CrossFade("idlewKnife");
                }
                break;
            case 4:
                if (anim.IsPlaying("walkwrifle") == false)
                {
                    anim.CrossFade("walkwrifle");
                }
                break;
            case 5:
                if (anim.IsPlaying("walkwpistol") == false)
                {
                    anim.CrossFade("walkwpistol");
                }
                break;
            case 6:
                if (anim.IsPlaying("walkwknife") == false)
                {
                    anim.CrossFade("walkwknife");
                }
                break;
        }

    }
}
