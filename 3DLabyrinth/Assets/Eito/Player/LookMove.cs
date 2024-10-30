using UnityEngine;

// プレイヤーにアタッチして使います
public class LookMove : MonoBehaviour
{
    // カメラ感度はstaticになりました(拍手)

    // 自分の周りに物が回っているようにふるまって、そこに自分を向ける　という仕組み
    // だがより良い方法があったのでリファクタの時間が取れれば修正したい　
    Vector3 m_targetPos;
    private Vector3 m_targetOffset = new Vector3(0, 0, 10);
    private GameObject m_camera;

    private float m_xRotate;
    private float m_yRotate;

    public static bool s_canLookMove = true;

    private void Start()
    {
        m_targetPos = transform.position + m_targetOffset;
        m_camera = transform.GetChild(0).gameObject;
        s_canLookMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        // カメラ感度は別スクリプト
        m_xRotate = Input.GetAxis("HorizontalRight") * GameSettingManager.s_xSensitivity;
        m_yRotate = Input.GetAxis("VerticalRight") * -GameSettingManager.s_ySensitivity;
    }

    public static void SetCanMove(bool canMove)
    {
        s_canLookMove = canMove;
    }

    private void FixedUpdate()
    {
        // 動けるかどうか
        if (!s_canLookMove) return;

        float angle = Vector3.SignedAngle(new Vector3(m_targetOffset.x, 0, m_targetOffset.z), m_targetOffset, -transform.right);
        //Debug.Log(angle);

        // カメラの向きの制限
        if (angle > 80)
        {
            if (m_yRotate > 0)
            {
                m_yRotate = 0;
            }
            //Debug.Log("aaa");
        }
        if (angle < -80)
        {
            if (m_yRotate < 0)
            {
                m_yRotate = 0;
            }
            //Debug.Log("aaa");
        }

        // クオータニオン使う
        Quaternion quaternionX = Quaternion.AngleAxis(m_xRotate * Time.fixedDeltaTime, Vector3.up);
        // 自身の向きに合わせて上下の視点移動の軸は変えないといけないっぽい
        Quaternion quaternionY = Quaternion.AngleAxis(m_yRotate * Time.fixedDeltaTime, -transform.right);

        m_targetOffset = quaternionX * m_targetOffset;
        m_targetOffset = quaternionY * m_targetOffset;
        // あとプレイヤーも回転
        transform.rotation *= quaternionX;

        // 計算結果をターゲットに反映
        m_targetPos = transform.position + m_targetOffset;

        //Debug.Log(_targetPos);

        // Unityに
        m_camera.transform.LookAt(m_targetPos);
    }
}
