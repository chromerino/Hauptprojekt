using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{

static int maxHeight = 16;
static float smooth = 0.1f;
static int octaves = 4;
static float persistence = 0.5f;
public static int seed {get; set;}
static int waterlevel=0;

	static float Map(float newmin, float newmax, float origmin, float origmax, float value){
		return Mathf.Lerp(newmin, newmax, Mathf.InverseLerp(origmin, origmax, value));
	}
	public static int GenerateFloorHeight(float x, float z){
	float height=0;
	int maxHeightTemp=(int)(maxHeight*0.75);
	

		height += Map(0, (int) (maxHeightTemp), 0, 1, fBM((x+seed*2)*smooth/5,(z+seed*2)*smooth/5, octaves+2, persistence));
		
		return (int) height;
	}	
	public static int getWaterLevel(){
		if(waterlevel==0){
			waterlevel=GenerateFloorHeight(0,0);
		}
		return waterlevel;
	}
	public static int GenerateHeight(float x, float z){
	float height=0;
	int maxHeightTemp=maxHeight;
	if(x<=World.worldSize*World.chunkSize/20 || x>=World.worldSize*World.chunkSize/20*19 || 
		z<=World.worldSize*World.chunkSize/20 || z>=World.worldSize*World.chunkSize/20*19){
		height=20;
		}else{
	/*
	    if(x<=World.worldSize*World.chunkSize/10 || x>=World.worldSize*World.chunkSize/10*9 || 
		z<=World.worldSize*World.chunkSize/10 || z>=World.worldSize*World.chunkSize/10*9){
		height+=2;
		maxHeightTemp+=5;
		if(x<=World.worldSize*World.chunkSize/20 || x>=World.worldSize*World.chunkSize/20*19 || 
		z<=World.worldSize*World.chunkSize/20 || z>=World.worldSize*World.chunkSize/20*19){

		height+=5;
		maxHeightTemp+=12;

		}
		}
		if(x>=World.worldSize*World.chunkSize/10*4 && x<=World.worldSize*World.chunkSize/10*6 && z>=World.worldSize*World.chunkSize/10*4 && z<=World.worldSize*World.chunkSize/10*6){

		
		maxHeightTemp+=5;

		}*/
		height += Map(0, maxHeight, 0, 1, fBM((x+seed)*smooth,(z+seed)*smooth, octaves, persistence));
		}
		return (int) height;
	}
	static float fBM(float x, float z, int oct, float pers){
		float total = 0;
		float frequency = 1;
		float amplitude = 1;
		float maxValue = 0;
		for(int i=0; i< oct; i++){
		total+=Mathf.PerlinNoise(x*frequency, z*frequency)*amplitude;
		maxValue+=amplitude;
		amplitude*=pers;
		frequency*=2;

		}
		return total/ maxValue;
	}

	
}
