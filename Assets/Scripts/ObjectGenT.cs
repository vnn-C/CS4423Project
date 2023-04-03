using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenT : MonoBehaviour
{
    public GameObject stopper;
    public GameObject booster;
    public GameObject ramp;
    
    // Start is called before the first frame update
    void Start()
    {
       generateThing(); 
    }

   

    void generateThing(){


        StartCoroutine(GenerateObjects());

    //coin generator
       
        IEnumerator GenerateObjects(){
            Debug.Log("GENERATION START!");

            while(true){

                int newRand = Random.Range(0,12);
                int randTime = Random.Range(0,10);

                if(newRand == 0){
                    Vector2 rampPos = new Vector2(Random.Range(-6f,10f), -6);
                    GameObject newRamp = Instantiate(ramp, rampPos, Quaternion.identity);
                }
                else if(newRand <= 6){
                    Vector2 boosterPos = new Vector2(Random.Range(-6f,10f), -6);
                    GameObject newBooster = Instantiate(booster, boosterPos, Quaternion.identity);
                    /*if(newBooster.transform.position.x <= -5){
                        Destroy(newBooster);
                        Debug.Log("Booster Destroyed\n");
                    }*/
                }
                else if(newRand < 12){
                    Vector2 stopperPos = new Vector2(Random.Range(-6f,10f), -6);
                    GameObject newStopper = Instantiate(stopper, stopperPos, Quaternion.identity);
                    /*if(newStopper.transform.position.x <= -5){
                        Destroy(newStopper);
                        Debug.Log("Stopper Destroyed\n");

                    }*/
                }
                else{
                    Debug.Log("Dud\n");
                }
                
                

                

                yield return new WaitForSeconds((float)(0.2 * randTime));
            }
           
        }
    }
}
