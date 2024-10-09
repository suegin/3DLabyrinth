using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.position = new Vector3(Mathf.Sin(Time.time) * 5.0f + targetPos.x, targetPos.y, targetPos.z); // Xé≤ÇÃç∂âEà⁄ìÆ
    }
}
