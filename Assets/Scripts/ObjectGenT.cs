using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenT : MonoBehaviour
{
    public GameObject stopper;
    public GameObject booster;
    public GameObject ramp;
    public int maxNumOfBooster = 1;
    public int maxNumOfStopper = 1;
    public int maxNumOfRamp = 1;
    public static int boosterCount = 0;
    public static int stopperCount = 0;
    public static int rampCount = 0;
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

                if(newRand == 0 && rampCount < maxNumOfRamp){
                    Vector2 rampPos = new Vector2(Random.Range(-6f,10f), -6);
                    GameObject newRamp = Instantiate(ramp, rampPos, Quaternion.identity);
                    rampCount+=1;
                }
                else if(newRand <= 6 && boosterCount < maxNumOfBooster){
                    Vector2 boosterPos = new Vector2(Random.Range(-6f,10f), -6);
                    GameObject newBooster = Instantiate(booster, boosterPos, Quaternion.identity);
                    /*if(newBooster.transform.position.x <= -5){
                        Destroy(newBooster);
                        Debug.Log("Booster Destroyed\n");
                    }*/
                    boosterCount+=1;
                }
                else if(newRand < 12 && stopperCount < maxNumOfBooster){
                    Vector2 stopperPos = new Vector2(Random.Range(-6f,10f), -6);
                    GameObject newStopper = Instantiate(stopper, stopperPos, Quaternion.identity);
                    /*if(newStopper.transform.position.x <= -5){
                        Destroy(newStopper);
                        Debug.Log("Stopper Destroyed\n");

                    }*/
                    stopperCount+=1;
                }
                else{
                    Debug.Log("Dud\n");
                }
                
                

                

                yield return new WaitForSeconds((float)(0.2 * randTime));
            }
           
        }
    }
}
