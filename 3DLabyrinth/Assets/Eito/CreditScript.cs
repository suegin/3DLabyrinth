using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    private Vector3 staffrollPosition;
    public RectTransform rectTransform; // �X�N���[�����������̂�����
    public float endPos; // �X�N���[�����I���ۂ�Y���W�̎w��

    // Start is called before the first frame update
    void Start()
    {
        staffrollPosition = rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // A�{�^���������ƃX�N���[���X�s�[�h���オ��
        if (Input.GetKey("joystick button 0"))�@
        {
            staffrollPosition.y += 1f;
        }

        // +Y���W�ɃX�N���[������
        if (rectTransform.anchoredPosition.y < endPos)
        {
            staffrollPosition.y += 0.3f;
            rectTransform.anchoredPosition = staffrollPosition;
        }
    }
}
