using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleRelocate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

       
        if(other.tag == "booster" || other.tag == "stopper" || other.tag == "ramp"){
            Vector2 newPos = new Vector2(Random.Range(-8f,10f), -8);
            other.gameObject.transform.position = newPos;
        }
        //Destroy(other.gameObject);
        
        /*if(other.tag == "booster"){
            ObjectGenT.boosterCount -= 1;   
            Debug.Log("Booster destroyed"); 
        }
        else if(other.tag == "stopper"){
            ObjectGenT.stopperCount -= 1;
            Debug.Log("Stopper destroyed");
        }
        else if(other.tag == "ramp"){
            ObjectGenT.rampCount -= 1;
            Debug.Log("Ramp destroyed");
        }*/
    }
}
