using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    public DoorScript door; // ドアスクリプトとの連動
    [SerializeField]
    private AudioClip m_targetSE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !door.isOpen)　// 初回のボールが当たったら
        {
            door.DoorOpen();
            // SEを鳴らす
            SEGenerator.GenerateSEAtPoint(transform.position, m_targetSE);
            // お隣のスクリプトに止めろと指示を出す
            GetComponent<TargetScript>().SetCanMove(false);
        }
    }
}
