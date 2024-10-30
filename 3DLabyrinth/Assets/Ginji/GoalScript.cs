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

    //ゲームオブジェクトに当たったとき
    private void Update()
    {
        if (fadeOut.isFade)
        {
            SceneManager.LoadScene("Eito/Scene/ClearScene");    //クリアシーンに遷移
            Debug.Log("clear");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //当たったゲームオブジェクトがPlayerタグだったとき
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーを動けなくする
            collision.gameObject.GetComponent<PlayerMove>().Stop();
            // staticなんですか…
            LookMove.SetCanMove(false);

            fadeOut.ChangeScene();
            //Debug.Log("a");
        }
    }
}
