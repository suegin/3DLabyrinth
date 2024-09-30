using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // オブジェクトが衝突したとき
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name);
    }

    // オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit: " + collision.gameObject.name);
    }

    // オブジェクトが触れている間
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay: " + collision.gameObject.name);
    }

    /* オブジェクト同士の重なり判定 */
    // オブジェクトが重なったとき
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.gameObject.name);
    }

    // オブジェクトが離れた時
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit: " + other.gameObject.name);
    }

    // オブジェクトが重なっている間
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay: " + other.gameObject.name);
    }
}
