using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // プレイヤーが触れたらジャンプ
    public Vector3 m_jumpForce = new Vector3(0.0f, 10.0f, 0.0f);

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Player" || tag == "Ball")
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            // 回転を神
            rigidbody.AddForce(transform.rotation * m_jumpForce, ForceMode.Impulse);
        }
    }
}
