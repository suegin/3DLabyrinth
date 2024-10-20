using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移動する

    private float x_sensitivity = 20f;
    private float y_sensitivity = 20f;

    private float m_xMove = 0;
    private float m_zMove = 0;　

   // private bool isRunning; // 移動しているかしていないかのフラグ
   // private AudioSource audioSource;

    private Rigidbody m_rigidbody;

    public static bool s_canMove = true;

   // public AudioClip footStep; // 流す足音の設定

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
       // audioSource = GetComponent<AudioSource>();
       // isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_xMove = Input.GetAxis("Horizontal") * x_sensitivity;
        m_zMove = Input.GetAxis("Vertical") * y_sensitivity;
    }

    private void FixedUpdate()
    {
        // メニューが開いていたりしているときに動きを止めたい
        if (!s_canMove) return;

        // いい感じに自分の向きにあわせてAddForceを回転させたい
        //Debug.Log(transform.eulerAngles);
        Vector3 power = new Vector3(m_xMove, 0, m_zMove);
        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.AddForce(power);
    }
}
