// Player.cs
using UnityEngine;

// �v���C���[
public class Player : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;              // �ړ�����
    [SerializeField] private float moveSpeed = 5.0f;        // �ړ����x
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

        // WASD���͂���AXZ����(�����Ȓn��)���ړ��������(velocity)�𓾂܂�
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

        // ���x�x�N�g���̒�����1�b��moveSpeed�����i�ނ悤�ɒ������܂�
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // �����ꂩ�̕����Ɉړ����Ă���ꍇ
        if (velocity.magnitude > 0)
        {
            // �v���C���[�̈ʒu(transform.position)�̍X�V
            // �ړ������x�N�g��(velocity)�𑫂����݂܂�
            transform.position += velocity;
        }
    }
}