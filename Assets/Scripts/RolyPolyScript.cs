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

    // Start is called before the first frame update
    void Start()
    {
        thingRigid = GetComponent<Rigidbody2D>();
    }

    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "booster"){
            Debug.Log("Boost");
            GameSpeed.rpSpeed *= (float)1.2;
        }
        else if(other.tag == "stopper"){
            Debug.Log("Stop");
            if(GameSpeed.rpSpeed > 1){
                GameSpeed.rpSpeed *= (float)0.5;
            }
        }
        else if(other.tag == "ramp"){
            GameSpeed.rpSpeed *= (float)1.5;
            thingRigid.gravityScale = 100;
            canJump = true;
            //Vector2 jump = new Vector2
            thingRigid.AddForce(Vector3.up * 10 * GameSpeed.rpSpeed, ForceMode2D.Impulse);
            Wait(airTime);

            //thingRigid.velocity = Vector2.up * Time.fixedDeltaTime * 10000;
        }
        else if(other.tag == "reset"){
            thingRigid.gravityScale = 0;
        }

    }


void FixedUpdate(){
        if(canJump){
            //thingRigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            canJump = false;
            //thingRigid.gravityScale = 0;
        }
        else{
            thingRigid.MovePosition(transform.position + (new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Horizontal") * (float)0.7) * Time.fixedDeltaTime * moveSpeed));
        }
        if(Input.GetKey(KeyCode.E) && GameSpeed.rpSpeed > 0){
            GameSpeed.rpSpeed-=(float)0.01;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //GameSpeed.momentumRP();
        
    }

    public IEnumerator Wait(float airTime){
        yield return new WaitForSeconds(airTime);
    }
}
