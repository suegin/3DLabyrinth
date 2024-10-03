using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCaster : MonoBehaviour
{
    private Image m_cursor;
    private Color m_red = new Color(1, 0, 0);
    private Color m_gray = new Color(0.8f, 0.8f, 0.8f);

    // 自分の状態
    private bool m_isGrabbingBall = false;
    public bool isCatchedCollider {  get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        m_cursor = GameObject.Find("Cursor").GetComponent<Image>();
    }

    void FixedUpdate()
    {
        // ボールを見る
        Ray();

        // 入力とる ネストが気に入らなかったので早期return
        if (!Input.GetKeyDown("joystick button 0")) return;

        if (m_isGrabbingBall)
        {
            // 離す処理 長くなるから関数化
            m_isGrabbingBall = false;
        }
        else if ()
        {
            // 握る処理

        }
    }

    private void Ray()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10);

        // まず対象はないとして考える
        isCatchedCollider = false;
        m_cursor.color = m_gray;

        // コライダーがnullならreturn
        if (hit.collider == null) return;

        if (hit.collider.tag == "Ball")
        {
            isCatchedCollider = true;
            m_cursor.color = m_red;
        }
    }

    private void Catch()
    {

    }

    private void Grab()
    {

    }

    private void Throw()
    {

    }
}
