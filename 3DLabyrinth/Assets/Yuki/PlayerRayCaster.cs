using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCaster : MonoBehaviour
{
    private Image m_cursor;
    private Color m_red = new Color(1, 0, 0);
    private Color m_gray = new Color(0.8f, 0.8f, 0.8f);
    private Vector3 m_grabPosition = new Vector3(0.5f, -0.2f, 0.7f);
    private const float kThrowPower = 15f;

    // 自分の状態
    private bool m_isGrabbingBall = false;
    public bool isCatchedCollider {  get; private set; }

    // 今例キャストに入っているオブジェクト
    private RaycastHit m_raycastHit;
    // 今持っているゲームオブジェクト
    private GameObject m_grabObject;
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

        // すでにボールを持っていたら
        if (m_isGrabbingBall)
        {
            // 離す処理 長くなるから関数化
            Throw();
            m_isGrabbingBall = false;
        }
        // でなくて、視界にボールがあるなら
        else if (isCatchedCollider)
        {
            // 握る処理
            Grab();
            m_isGrabbingBall = true;
        }
    }

    private void Ray()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out m_raycastHit, 10);

        // まず対象はないとして考える
        isCatchedCollider = false;
        m_cursor.color = m_gray;

        // コライダーがnullならreturn
        if (m_raycastHit.collider == null) return;

        if (m_raycastHit.collider.tag == "Ball")
        {
            isCatchedCollider = true;
            m_cursor.color = m_red;
        }
    }

    private void Grab()
    {
        Debug.Log("つかんだ");
        // 自身のメンバ変数に記録
        m_grabObject = m_raycastHit.collider.gameObject;
        // 見てるオブジェクトを自分の子供に
        // メソッドチェーンすごいけど
        m_grabObject.transform.SetParent(transform, true);
        // そのオブジェクトを特定の位置に移動(つかむ感じ)
        m_grabObject.transform.localPosition = m_grabPosition;
        // オブジェクトの物理演算を無効化する
        m_grabObject.GetComponent<Rigidbody>().isKinematic = true;
        m_grabObject.GetComponent<SphereCollider>().enabled = false;
    }

    private void Throw()
    {
        Debug.Log("投げる");
        // 無効化していた物理を復活させる
        m_grabObject.GetComponent<Rigidbody>().isKinematic = false;
        m_grabObject.GetComponent<SphereCollider>().enabled = true;
        // 親子関係解除
        m_grabObject.transform.SetParent(null);
        // 自分(カメラ)の向きにAddForce
        m_grabObject.GetComponent<Rigidbody>()
            .AddForce(transform.forward * kThrowPower, ForceMode.Impulse);
    }
}
