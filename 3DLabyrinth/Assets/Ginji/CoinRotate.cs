using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    private float m_rotaSpeed = 20.0f;
    private RectTransform m_rectTransform;

    private void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        m_rectTransform.Rotate(0.0f, 0.0f, m_rotaSpeed * Time.deltaTime);
    }
}
