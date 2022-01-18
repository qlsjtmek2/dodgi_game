using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public AudioManager audioManager;

    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public JoyStick joystick;
    public float MoveSpeed; // 플레이어 이동속도

    private Vector3 _moveVector;
    private Transform _transform;

    Animator anim;
    AudioSource audioSource;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _transform = transform; // 트랜스폼 캐싱
        _moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
    }

    void Update()
    {
        HandleInput(); // 터치패드 입력받기

        if (gameManager.gameOver)
        {
            anim.SetBool("Dead", gameManager.gameOver); // 죽으면 사망 애니메이션
        }
    }

    private void FixedUpdate()
    {
        Move(); // 플레이어 이동
    }

    public void HandleInput()
    {
        _moveVector = poolInput();
    }

    public Vector3 poolInput()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();

        // 벽 충돌 체크
        if ((isTouchRight && h > 0) || (isTouchLeft && h < 0))
            h = 0;
        if ((isTouchTop && v > 0) || (isTouchBottom && v < 0))
            v = 0;

        Vector3 moveDir = new Vector3(h, v, 0);

        return moveDir;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }

        else if (collision.gameObject.tag == "Enemy" && !gameManager.gameOver)
        {
            gameManager.GameOver();
            joystick.joystickSetZero();
            audioManager.soundDie();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }

    public void Move()
    {
        _transform.Translate(_moveVector * MoveSpeed * Time.deltaTime);
    }
}
