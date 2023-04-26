using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolyPolyFR : MonoBehaviour
{
    Rigidbody2D thingRigid;
    bool downMovement = true;
    bool upMovement = false;
    public GameObject gameOverLayer;
    public GameObject scoreCounter;
    public GameObject tryAgain;
    public GameObject mainMenu;
    public AudioSource drumRoll;
    // Start is called before the first frame update
    void Start()
    {
        thingRigid = GetComponent<Rigidbody2D>();  
        drumRoll.Play();
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
        if(downMovement){
            thingRigid.MovePosition(transform.position + (new Vector3((float)0.7 * GameSpeed.finalSpeed,(float)-0.7 * GameSpeed.finalSpeed) * Time.fixedDeltaTime));

        }
        if(downMovement && transform.position.y < -3.5){
            downMovement = false;
            upMovement = true;
        }

        if(upMovement){
            thingRigid.MovePosition(transform.position + (new Vector3((float)0.7 * GameSpeed.finalSpeed,(float)0.7 * GameSpeed.finalSpeed) * Time.fixedDeltaTime));
        }
        if(transform.position.y > -1.07 && GameSpeed.finalSpeed < (float)10 && upMovement){
            drumRoll.Stop();
            upMovement = false;
            thingRigid.AddForce(Vector3.up * 5 * GameSpeed.finalSpeed, ForceMode2D.Impulse);
            thingRigid.gravityScale = 100;
            ScoreCalc.ScoreCalculator();
            
            Invoke("showResults",2);

        }
        if(transform.position.x > 9 && upMovement){
            drumRoll.Stop();
            upMovement = false;
            ScoreCalc.ScoreCalculator();

            Invoke("showResults",2);

            

        }
    }
}
