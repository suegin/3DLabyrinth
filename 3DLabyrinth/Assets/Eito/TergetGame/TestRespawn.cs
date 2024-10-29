using UnityEngine;

public class TestRespawn : MonoBehaviour
{
    private GameObject m_RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        m_RespawnPoint = transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))　// 接触したオブジェクトのタグがBallかを比較
        {
            Respawn(other.gameObject);
        }
    }

    public void Respawn(GameObject obj)
    {
        // 親子関係があるかもしれないので解除しておく
        obj.transform.parent = null;
        // 速度を0に RigidBodyがないやつはないはず
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = m_RespawnPoint.transform.position; // スタート位置に戻す
    }
}
