using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    GameObject player; 

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(5.0f, 1.0f, -20.0f);
        }
    }
}
