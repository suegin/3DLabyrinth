using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private bool m_canMove = true;

    private float m_moveSpeed = 10f;

    private Vector3 m_inputAxis = Vector3.zero;

    private Rigidbody m_rigidbody;

    // ポーズ時に移動速度を記録
    private Vector3 m_pausedVelocity = Vector3.zero;

   // public AudioClip footStep; // 流す足音の設定

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_inputAxis.x = Input.GetAxis("Horizontal");
        m_inputAxis.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // 移動を禁ずる
        if (!m_canMove)
        {
            m_inputAxis = Vector3.zero;
            return;
        }

        // いい感じに自分の向きにあわせてAddForceを回転させたい
        // 入力が1以上にならないようにする
        if (m_inputAxis.sqrMagnitude > 1)
        {
            m_inputAxis.Normalize();
        }
        m_inputAxis *= m_moveSpeed;

        // 重力以外を設定
        Vector3 power = new Vector3(m_inputAxis.x, m_rigidbody.velocity.y, m_inputAxis.z);

        power = Quaternion.AngleAxis(transform.eulerAngles.y, transform.up) * power;
        m_rigidbody.velocity = power;
    }

    public void Stop()
    {
        // 移動を止める
        m_pausedVelocity = m_rigidbody.velocity;
        m_rigidbody.useGravity = false;
        m_rigidbody.velocity = Vector3.zero;
        m_canMove = false;
    }

    // 移動量の保存を行わないStop関数
    public void KillVelocityStop()
    {
        m_pausedVelocity = Vector3.zero;
        m_rigidbody.useGravity = false;
        m_rigidbody.velocity = Vector3.zero;
        m_canMove = false;
    }

    public void Resume()
    {
        // 移動再開
        m_rigidbody.useGravity = true;
        m_rigidbody.velocity = m_pausedVelocity;
        m_pausedVelocity = Vector3.zero;
        m_canMove = true;
    }
}
