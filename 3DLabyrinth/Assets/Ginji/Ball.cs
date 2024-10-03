using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BallThrow()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        Vector3 ballForce = new Vector3(0.0f, 20.0f, 20.0f);
        rigidBody.AddForce(ballForce, ForceMode.Impulse);
    }
}
