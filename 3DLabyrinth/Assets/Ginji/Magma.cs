using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    Vector3 transPos = new Vector3(0, 0, 0);

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
            player.transform.position = transPos;
        }
    }
}
