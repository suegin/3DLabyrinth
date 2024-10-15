using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    Vector3 staffrollPosition;
    public RectTransform rectTransform;
    public float endPos;


    // Start is called before the first frame update
    void Start()
    {
        staffrollPosition = rectTransform.anchoredPosition;

    }

    // Update is called once per frame
    void Update()
    {

        if (rectTransform.anchoredPosition.y < endPos)
        {

            staffrollPosition.y += 3f;
            rectTransform.anchoredPosition = staffrollPosition;
        }

    }
}
