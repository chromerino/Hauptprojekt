using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Hearts : MonoBehaviour
{

    // Start is called before the first frame update
	public GameObject[] Heart;
	public Sprite EmptySprite;
	public Sprite HalfSprite;
	public Sprite FullSprite;
    public static double MaxHealth=10;
	public double CurrentHealth=6;
	private Image sr;


	void Start(){
	
	if(10<MaxHealth){
	MaxHealth=10;
    }
	CurrentHealth=MaxHealth;
	
	}

void FixedUpdate(){

    if(CurrentHealth<0){
	   CurrentHealth=0;
    }else if(CurrentHealth>=MaxHealth){
	   CurrentHealth=MaxHealth;
    }

    for(int i=0; i<10; i++){

       empty(i);
    }

    for(double i=0.5; i<=10; i+=0.5 ){

       if(i%1!=0){
           if(CurrentHealth>=i ){
	           half(Convert.ToInt32(Math.Floor(i)));
           }else{
	           empty(Convert.ToInt32(Math.Floor(i)));
           } 
	   }else{
	        if(CurrentHealth>=i){
		        full(Convert.ToInt32(Math.Floor(i))-1);
	        }
       }
    }
}

void empty(int i) {
    sr=Heart[i].GetComponent<Image>();
	sr.sprite = EmptySprite;
}

void half(int i) {
    sr=Heart[i].GetComponent<Image>();
	sr.sprite = HalfSprite;
}
    
void full(int i) {
    sr=Heart[i].GetComponent<Image>();
	sr.sprite = FullSprite;
}

}