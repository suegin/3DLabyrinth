using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // プレイヤーが触れたらジャンプ
    [SerializeField]
    private Vector3 m_jumpForce = new Vector3(0.0f, 5.0f, 0.0f);
    [SerializeField]
    private AudioClip m_jumpSE;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Player" || tag == "Ball")
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            // 回転を神
            rigidbody.AddForce(transform.rotation * m_jumpForce, ForceMode.Impulse);
            // SE鳴らす
            SEGenerator.GenerateSEAtPoint(transform.position, m_jumpSE);
        }
    }
}
