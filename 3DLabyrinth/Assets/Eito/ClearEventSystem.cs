using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearEventSystem : MonoBehaviour
{
    // ��莞�Ԍ�Ƀ{�^���Ƀt�H�[�J�X����
    [SerializeField]
    private GameObject m_button;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FacusOnButton(2.0f));
    }

    private IEnumerator FacusOnButton(float time)
    {
        yield return new WaitForSeconds(time);
        EventSystem.current.SetSelectedGameObject(m_button);
    }
}
