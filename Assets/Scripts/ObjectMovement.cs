using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    public float speed = GameSpeed.rpSpeed;
    public float factor = 0;
    Rigidbody2D obstacleRigid;


    // Start is called before the first frame update
    void Start()
    {
        obstacleRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        obstacleRigid.MovePosition(transform.position + (new Vector3(-GameSpeed.rpSpeed,GameSpeed.rpSpeed) * (float)0.4 * Time.fixedDeltaTime));       
    }
}
