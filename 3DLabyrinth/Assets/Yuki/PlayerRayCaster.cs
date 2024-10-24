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
    private const float kRayLength = 5f;

    //AudioSource audioSource;
    //public AudioClip ballGrab;
    //public AudioClip ballThrow;
    // 自分の状態
    private bool m_isGrabbingBall = false;
    public bool isCatchedBallCollider = false;
    public bool isCatchedSwitchCollider = false;

    // 今例キャストに入っているオブジェクト
    private RaycastHit m_raycastHit;
    // 今持っているゲームオブジェクト
    private GameObject m_grabObject;
    void Start()
    {
        m_cursor = GameObject.Find("Cursor").GetComponent<Image>();
       // audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // オブジェクトを見る
        Ray();

        // 入力が無ければ早期return 
        if (!Input.GetKeyDown("joystick button 0")) return;

        // 目の前にスイッチがある
        if (isCatchedSwitchCollider)
        {
            PressSwitch();
        }
        // そうでなく、ボールを持っていたら
        else if (m_isGrabbingBall)
        {
            // 離す処理 長くなるから関数化
            Throw();
            m_isGrabbingBall = false;
        }
        // でなくて、視界にボールがあるなら
        else if (isCatchedBallCollider)
        {
            // 握る処理
            Grab();
            m_isGrabbingBall = true;
        }
    }

    private void Ray()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            out m_raycastHit, kRayLength);

        // まず対象はないとして考える
        isCatchedBallCollider = false;
        isCatchedSwitchCollider = false;
        m_cursor.color = m_gray;

        // コライダーがnullならreturn
        if (m_raycastHit.collider == null) return;

        // コライダーがあるならタグを取得して
        string tag = m_raycastHit.collider.tag;
        // 指定したタグと見比べていく
        switch (tag)
        {
            case "Ball":
                isCatchedBallCollider = true;
                m_cursor.color = m_red;
                break;
            case "Switch":
                isCatchedSwitchCollider = true;
                m_cursor.color = m_red;
                break;
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
       // audioSource.Play();
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
       // audioSource.Play();
    }

    private void PressSwitch()
    {
        // レイ上のスイッチに押される命令を出すだけ
        // インターフェースはGetComponentできるのか
        m_raycastHit.collider.gameObject
            .GetComponent<ISwitch>().Interact();
    }
}
