using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Q�[������1�������݂���
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �t���[�����[�g��60�ɌŒ�
        Application.targetFrameRate = 60;
        // �����DontDestroy�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
