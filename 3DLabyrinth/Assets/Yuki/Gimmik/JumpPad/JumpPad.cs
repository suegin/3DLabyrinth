using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // プレイヤーが触れたらジャンプ
    Vector3 m_jumpForce = new Vector3(0.0f, 25.0f, 0.0f);

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Player" || tag == "Ball")
        {
            other.GetComponent<Rigidbody>().AddForce(m_jumpForce, ForceMode.Impulse);
        }
    }
}
