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
        transform.Translate(new Vector3 (Mathf.Cos(Time.time * 2) * 8.0f * Time.deltaTime, 0.0f, 0.0f)); // 左右移動
    }
}
