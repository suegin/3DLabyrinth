// Player.cs
using UnityEngine;

// プレイヤー
public class Player : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    private bool isRunning;
    AudioSource audioSource;
    public AudioClip footStep;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isRunning = false;
    }
    void Update()
    {
        if(!Input.GetKey(KeyCode.W) && 
            !Input.GetKey(KeyCode.A) && 
            !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.D))
        {
            if(!isRunning)
            {
                audioSource.Stop();
                isRunning = true;
            }
        }

        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += 1;
            if (isRunning)
            {
                audioSource.Play();
            }
            isRunning = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 1;
            if (isRunning)
            {
                audioSource.Play();
            }
            isRunning = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= 1;
            if (isRunning)
            {
                audioSource.Play();
            }
            isRunning = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
            if (isRunning)
            {
                audioSource.Play();
            }
            isRunning = false;
        }

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }
    }
}