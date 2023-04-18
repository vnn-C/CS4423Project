using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSpeed : MonoBehaviour
{
    // Start is called before the first frame update

    public static float rpSpeed = 2;
    public static float finalSpeed = 1;
    public float distance = 2500;
    public static float origDistance = 0;
    public static float curDistance = 0;
    public Text speedCounter;
    public Text distanceCounter;
    
    public string sceneName;
    void Start()
    {
        origDistance = distance;
        curDistance = distance;
    }

    public static void momentumRP(){
        //GameSpeed.rpSpeed *= (float)1.00001;    
            
        
    }

    // Update is called once per frame
    void Update()
    {
        rpSpeed += Mathf.Log((float)1.00001);  
        speedCounter.text = rpSpeed.ToString() + ": Speed";
        distance -= (rpSpeed * (float)0.01);
        distanceCounter.text = distance.ToString() + ": Distance";
        if(distance < 0){
            Debug.Log("Distance zero");
            finalSpeed = rpSpeed;
            //Application.Quit();
            SceneManager.LoadScene(sceneName);
        }

    }
}
