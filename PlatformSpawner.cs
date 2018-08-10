using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
	

	public GameObject platform;
    public GameObject wall;
    public GameObject diamond;
    public GameObject red;
    Vector3 lastPos;
	float size;
    public bool gameOver;
	
	void Start () {
		lastPos=platform.transform.position;
		size=platform.transform.localScale.x;
		for(int i=0;i<20;i++){
			SpawnPlatform();
		}
		
	}
	
    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f);
    }
	// Update is called once per frame
	void Update () {
      
		
	
		
		
	}
	
	void SpawnPlatform(){
        if (gameOver)
        {
            return;
        }

        int rand=Random.Range(0,6);
		if(rand<3){
			SpawnX();
            
        }
		else if(rand>=3){
			SpawnZ();
        }
	}
	
	void SpawnX(){
		Vector3 pos=lastPos;
		pos.x+=size;
		lastPos=pos;
            Instantiate(platform, pos, Quaternion.identity);
       
        
        int rand = Random.Range(0, 20);
        if (rand < 6)
        {
            Instantiate(diamond, new Vector3(pos.x,pos.y+ 0.6f, pos.z), diamond.transform.rotation);
        }
        else if(rand>18)
        {
            Instantiate(red, new Vector3(pos.x, pos.y + 0.6f, pos.z), diamond.transform.rotation);
        }
        else if (rand == 10)
        {
            Instantiate(wall, new Vector3(pos.x, pos.y + 0.9f, pos.z), wall.transform.rotation*Quaternion.Euler(0, 90, 0));
        }

    }
	
	void SpawnZ(){
		Vector3 pos=lastPos;
		pos.z+=size;
		lastPos=pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 20);
        if (rand < 6)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 0.6f, pos.z), diamond.transform.rotation);
        }
        else if (rand > 18)
        {
            Instantiate(red, new Vector3(pos.x, pos.y + 0.6f, pos.z), diamond.transform.rotation);
        }
        else if (rand == 10)
        {
            Instantiate(wall, new Vector3(pos.x, pos.y + 0.9f, pos.z), wall.transform.rotation);
        }

    }

}
