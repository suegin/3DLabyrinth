using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    GameObject player;
    GameObject ball;
    [SerializeField]
    Vector3 transPos = new Vector3(0, 0, 0);
    [SerializeField]
    private AudioClip m_burnSE;
    private FadeOut m_fadeOut;

    private void Start()
    {
        player = GameObject.Find("Player");
        ball = GameObject.Find("Ball");
        m_fadeOut = GameObject.Find("FadeManager").GetComponent<FadeOut>();
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Burning());
        }

        if(collision.gameObject.CompareTag("Ball"))
        {
            collision.transform.position = transPos;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private IEnumerator Burning()
    {
        // �v���C���[���~�߂�
        // ����ς����͖��߂��Ă��銴�������Ȃ��̂Ŋ֐������̂͑厖�l
        // ���ƕ����s�ɂ܂��������肷�邩��l
        LookMove.SetCanMove(false);
        player.GetComponent<PlayerMove>().KillVelocityStop();

        // ���ʉ���炷
        SEGenerator.GenerateSEAtPoint(transform.position, m_burnSE);
        // �t�F�[�h�A�E�g
        yield return YukiFadeManager.FadeOut(2.0f);
        // �v���C���[�̍��W�̈ړ�
        player.transform.position = transPos;
        // �t�F�[�h�C��
        yield return YukiFadeManager.FadeIn(0.5f);

        // �v���C���[�̓�����������
        LookMove.SetCanMove(true);
        player.GetComponent<PlayerMove>().Resume();
    }
}
