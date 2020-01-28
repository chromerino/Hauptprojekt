using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation3rd : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public int mode;
    public Animation anim;

    void Update()
    {
        mode = GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().getAnimationMode();
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
                anim.Play("Char-BonesIdlewKnife");
                break;
            case 1:
                if (anim.IsPlaying("Char-Bones|idlewrifle") == false)
                {
                    anim.Play("Char-Bones|idlewrifle");
                }
                break;
            case 2:
                if (anim.IsPlaying("Char-Bones|idlewpistol") == false)
                {
                    anim.Play("Char-Bones|idlewpistol");
                }
                break;
            case 3:
                if (anim.IsPlaying("Char-Bones|idlewknife") == false)
                {
                    anim.Play("Char-Bones|idlewKnife");
                }
                break;
            case 4:
                if (anim.IsPlaying("Char-Bones|walkwrifle") == false)
                {
                    anim.Play("Char-Bones|walkwrifle");
                }
                break;
            case 5:
                if (anim.IsPlaying("Char-Bones|walkwpistol") == false)
                {
                    anim.Play("Char-Bones|walkwPistol");
                }
                break;
            case 6:
                if (anim.IsPlaying("Char-Bones|walkwknife") == false)
                {
                    anim.Play("Char-Bones|walkwKnife");
                }
                break;
        }

    }
}
