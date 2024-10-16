using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// パネルを左右に移動させるだけ
public class TargetScript : MonoBehaviour
{
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetPos.x, targetPos.y, Mathf.Sin(Time.time) * 5.0f + targetPos.z); // X軸の左右移動
    }
}
