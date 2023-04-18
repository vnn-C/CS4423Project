using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolyPolyJTH : MonoBehaviour
{
    Rigidbody2D thingRigid;
    public float scale = 6.0f;
    public GameObject gameOverLayer;
    public GameObject scoreCounter;
    public GameObject tryAgain;
    public GameObject mainMenu;
    public bool loadResult = true;

    // Start is called before the first frame update
    void Start()
    {
        thingRigid = GetComponent<Rigidbody2D>();      
    }

    void showResults(){
        scoreCounter.SetActive(true);
        gameOverLayer.SetActive(true);

        tryAgain.SetActive(true);
        mainMenu.SetActive(true);    
    }
    
    // Update is called once per frame
    void Update()
    {
        //scale -= 0.02f;
        //thingRigid.MovePosition(transform.position + (new Vector3((float)3,(float)3) * Time.fixedDeltaTime));
        if(scale >= 0){
        scale -= 0.015f;
        thingRigid.MovePosition(transform.position + (new Vector3((float)3,(float)3) * Time.fixedDeltaTime));
        transform.localScale = new Vector3(scale, scale, scale);
        }
        else if(loadResult){
            ScoreCalc.ScoreCalculator();
            loadResult = false;
            Invoke("showResults",1);
        }
    }

}
