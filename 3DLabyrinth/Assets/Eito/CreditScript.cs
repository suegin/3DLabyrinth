using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    private Vector3 staffrollPosition;
    private EventSystem m_eventSystem;
    
    public RectTransform rectTransform; // �X�N���[�����������̂�����
    public float endPos; // �X�N���[�����I���ۂ�Y���W�̎w��
    public GameObject creditView;
    public GameObject titleSceneView;

    // Start is called before the first frame update
    void Start()
    {
        staffrollPosition = rectTransform.anchoredPosition;
        m_eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        // A�{�^���������ƃX�N���[���X�s�[�h���オ��
        if (Input.GetKey("joystick button 0"))�@
        {
            staffrollPosition.y += 1f;
        }
        // B�{�^���������ƃ^�C�g���V�[���ɖ߂�
        if (Input.GetKey("joystick button 1"))
        {
            SceneManager.LoadScene(2); // �N���W�b�g���Z�b�g(�^�C�g���V�[���ă��[�h)
            creditView.SetActive(false);
            titleSceneView.SetActive(true);
            FocusButton();
        }

        // +Y���W�ɃX�N���[������
        if (rectTransform.anchoredPosition.y < endPos)
        {
            staffrollPosition.y += 0.3f; // �X�N���[���X�s�[�h
            rectTransform.anchoredPosition = staffrollPosition;
        }
    }

    private void FocusButton()
    {
        // UI�؂�ւ����ɂ�������s����΂��������Ƀt�H�[�J�X�����
        m_eventSystem.SetSelectedGameObject(GameObject.FindGameObjectWithTag("FirstSelectedButton"));
    }
}
