using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D thingRigid;
    void Start()
    {
        thingRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        thingRigid.MovePosition(transform.position + (new Vector3((float)-0.004 * GameSpeed.rpSpeed,(float)0.004 * GameSpeed.rpSpeed) * Time.fixedDeltaTime));
    }
}
