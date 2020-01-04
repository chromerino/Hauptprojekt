using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public int stamina;
    public int maxStamina;

    public int mode=0; // Current type of playermovement (0 crouching, 1 standing, 2 walking, 3 running)
    int count=0;
    void Start()
    {
        float progress= Mathf.Clamp01(1/maxStamina*stamina);
        slider.value=progress;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("mode: "+mode + ", stamina: "+stamina);
        /*
        if(Input.GetButtonDown("Vertical")){
           mode=0;
        }
        if(Input.GetButtonDown("Horizontal")){
           mode=1;
        }
        if(Input.GetButtonDown("Fire1")){
           mode=2;
        }
        if(Input.GetButtonDown("Fire2")){
           mode=3;
        }
       */
        if(stamina>=maxStamina){
            stamina=maxStamina;
        }
        //float progress= Mathf.Clamp01(1/maxStamina*stamina);
        float progress= (float)(1/(float)maxStamina)*(float)stamina;
        
        slider.value=progress;

if(count==05){
        int regMult=1;
        if(mode==0){
            regMult=3;
            addStamina(regMult);


        }else if(mode==1){
            regMult=2;
            addStamina(regMult);


        }else if(mode==2){
            regMult=1;
            addStamina(regMult);


        }else if(mode==3){
            regMult=2;
            subtractStamina(regMult);

 
        
        
        }
        count=0;
}else{
    count++;
}
    }
    public void setMode(int m){
		mode=m;
	}

    public void resetStamina()
    {
        stamina = maxStamina;
    }

    void addStamina(int amount)
    {
    stamina+= amount;
    }
    public int getStamina(){
        return stamina;
    }
    void subtractStamina(int amount)
    {
        
    stamina-= amount;
        if(stamina<0){
            stamina=0;

        } 
    }
}      

           



