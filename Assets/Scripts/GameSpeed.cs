using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    // Start is called before the first frame update

    public static float rpSpeed = 2;
    public static float finalSpeed = 1;
    public float distance = 2500;
    public Text speedCounter;
    public Text distanceCounter;
    void Start()
    {
        
    }

    public static void momentumRP(){
        //GameSpeed.rpSpeed *= (float)1.00001;    
            
        
    }

    // Update is called once per frame
    void Update()
    {
        rpSpeed *= (float)1.00001;  
        speedCounter.text = rpSpeed.ToString();
        distance -= (rpSpeed * (float)0.01);
        distanceCounter.text = distance.ToString();
        if(distance < 0){
            Debug.Log("Distance zero");
            //Application.Quit();
        }

    }
}
