using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public static float x_sensitivity = 100f;
    public static float y_sensitivity = 100f;
    public Slider slider;
    private float m_xRotate;
    private float m_yRotate;
    float v; // スライダーの数値によって感度を変えるための変数
    // Start is called before the first frame update
    void Start()
    {
       // Horizontal
       // Vertical
    }

    // Update is called once per frame
    void Update()
    {
        //m_xRotate = Input.GetAxis("Horizontal") * x_sensitivity * v;
        //m_yRotate = Input.GetAxis("Vertical") * y_sensitivity * v;
        //v = slider.value;
    }
}
