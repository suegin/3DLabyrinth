using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    [SerializeField]
    private FadeOut fadeOut;
    private void Start()
    {
        
    }

    //�Q�[���I�u�W�F�N�g�ɓ��������Ƃ�
    private void Update()
    {
        if (fadeOut.isFade)
        {
            SceneManager.LoadScene("Eito/Scene/ClearScene");    //�N���A�V�[���ɑJ��
            Debug.Log("clear");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //���������Q�[���I�u�W�F�N�g��Player�^�O�������Ƃ�
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[�𓮂��Ȃ�����
            collision.gameObject.GetComponent<PlayerMove>().Stop();
            // static�Ȃ�ł����c
            LookMove.SetCanMove(false);

            fadeOut.ChangeScene();
            //Debug.Log("a");
        }
    }
}
