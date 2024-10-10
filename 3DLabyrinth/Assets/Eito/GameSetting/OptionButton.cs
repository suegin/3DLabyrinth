using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionButton : MonoBehaviour
{
    private bool m_optionEnable = false;
    [SerializeField]
    GameObject m_UI;
    [SerializeField]
    GameObject m_firstSerectedButton;

    // Update is called once per frame
    void Update()
    {
        // スタートボタンを押したらオプションが出る
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            ShowOption();
        }
    }

    public void ShowOption()
    {
        if (m_optionEnable)
        {
            m_UI.SetActive(false);
            m_optionEnable = false;
            PlayerMove.s_canMove = true;
            LookMove.s_canLookMove = true;
        }
        else
        {
            m_UI.SetActive(true);
            // ボタンにフォーカス
            EventSystem.current.SetSelectedGameObject(m_firstSerectedButton);
            m_optionEnable = true;
            PlayerMove.s_canMove = false;
            LookMove.s_canLookMove = false;
        }
    }
}
