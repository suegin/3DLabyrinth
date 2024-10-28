using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukiImpactDoor : ToggleState
{
    private Vector3 m_speed = new Vector3(0, 1, 0);

    private Vector3 m_initPos;

    // Start is called before the first frame update
    void Start()
    {
        m_initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ƒIƒ“ƒIƒt‚Åˆ—‚ğ•Ï‚¦‚é
        if (GetState())
        {
            // ”ÍˆÍ‚Éû‚ß‚é
            if (transform.position.y < 8)
            {
                transform.Translate(m_speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y > m_initPos.y)
            {
                transform.Translate(-m_speed * Time.deltaTime);
            }
        }
    }
}
