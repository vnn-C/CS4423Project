using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RolyPolyScript : MonoBehaviour
{

    public float moveSpeed = 9;
    Rigidbody2D thingRigid;
    public float airTime = 1;
    bool canJump = false;
    public string sceneName;
    public static int boosterHit = 0;
    public static int stopperHit = 0;
    public static int rampHit = 0;
    public float rampGameOverSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        thingRigid = GetComponent<Rigidbody2D>();
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "booster"){
            Debug.Log("Boost");
            GameSpeed.rpSpeed *= (float)1.2;
            boosterHit += 1;
        }
        else if(other.tag == "stopper"){
            Debug.Log("Stop");
            if(GameSpeed.rpSpeed > 1){
                GameSpeed.rpSpeed *= (float)0.5;
                stopperHit += 1;
            }
        }
        else if(other.tag == "ramp"){
            GameSpeed.rpSpeed *= (float)1.5;
            thingRigid.gravityScale = 200;
            canJump = true;
            rampHit += 1;
            thingRigid.AddForce(Vector3.up * 18 * GameSpeed.rpSpeed, ForceMode2D.Impulse);
            //Wait(airTime);

               
        }
        else if(other.tag == "reset"){
            thingRigid.gravityScale = 0;
        }

    }


void FixedUpdate(){
        if(canJump){
            canJump = false;
            
        }
        else{
            if(transform.position.x > -9.8 && transform.position.x < 0.1){
                thingRigid.MovePosition(transform.position + (new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Horizontal") * (float)0.7) * Time.fixedDeltaTime * moveSpeed));
                
            }
            else if(transform.position.x >= 0.1){
                thingRigid.MovePosition(transform.position - (new Vector3((float)1, (float)1 * (float)0.7)));
                }
            else if(transform.position.x <= -9.8){
                thingRigid.MovePosition(transform.position + (new Vector3((float)1, (float)1 * (float)0.7)));
            }
        }
        if(Input.GetKey(KeyCode.E) && GameSpeed.rpSpeed > 0){
            GameSpeed.rpSpeed-=(float)0.01;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 11 && GameSpeed.rpSpeed > rampGameOverSpeed){
            Debug.Log("Jumped too high");
            GameSpeed.finalSpeed = GameSpeed.rpSpeed;
            SceneManager.LoadScene(sceneName);
        }
        if(transform.position.y > 11){
            thingRigid.gravityScale = 100;
        }
        
    }

    public IEnumerator Wait(float airTime){
        yield return new WaitForSeconds(airTime);
    }
}
