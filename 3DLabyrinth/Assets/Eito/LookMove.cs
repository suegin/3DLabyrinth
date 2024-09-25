using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMove : MonoBehaviour
{
    //private float x_sensitivity = 1f;
    //private float y_sensitivity = 1f;
    [SerializeField] GameObject player;

    Quaternion _quaternionX = Quaternion.identity;
    Quaternion _quaternionY = Quaternion.identity;
    Vector3 _targetPos;
    [SerializeField]
    GameObject test;
    private void Start()
    {
        _targetPos = transform.position + new Vector3(0, 0, 10);
    }
    // Update is called once per frame
    void Update()
    {
        float x_mouse = Input.GetAxis("Horizontal");
        float y_mouse = Input.GetAxis("Vertical");

        Debug.Log(x_mouse);
        Debug.Log(y_mouse);

        // クオータニオン使う
//        Quaternion quaternionX = Quaternion.AngleAxis(x_mouse, player.transform.up);
        _quaternionX *= Quaternion.AngleAxis(x_mouse, Vector3.up);
        _quaternionY *= Quaternion.AngleAxis(y_mouse, Vector3.right);

        //var newLookPos = _quaternionX * _quaternionY * Vector3.forward;
        _targetPos = _quaternionX * _quaternionY * _targetPos;

        // ちょっとテストで可視化してみる
        test.transform.position = _targetPos;

        //transform.LookAt(_targetPos);
//        transform.rotation *= quaternion;
    }
}
