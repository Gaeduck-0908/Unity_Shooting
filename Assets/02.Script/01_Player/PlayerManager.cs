using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class PlayerManager : Singleton<PlayerManager>
{
    // TODO
    // 플레이어의 정의 관련 코드 작성 바람

    // 플레이어의 체력
    public int Player_MaxHp = 100;
    public int Player_Hp;

    // 플레이어의 속도
    private float Player_Speed = 7f;

    // 플레이어의 무적모드
    private bool Player_God;

    // 플레이어의 레벨
    private int Player_Level;

    // 플레이어의 총알관련
    private float fireRate = 0.2f;
    private float nextFire = 0.0f;

    // 플레이어의 총알 오브젝트
    [SerializeField]
    private GameObject Player_Bullet_Lv1;
    [SerializeField]
    private GameObject Player_Bullet_Lv2;
    [SerializeField]
    private GameObject Player_Bullet_Lv3;
    [SerializeField]
    private GameObject Player_Bullet_Lv4;
    [SerializeField]
    private GameObject Player_Bullet_Lv5;

    // 플레이어의 컴포넌트
    private Image Player_img;
    private Collider2D Player_col;
    private Rigidbody2D rigid;

    public GameObject idle;
    public GameObject left;
    public GameObject right;

    // 최초 한번 실행
    private void Start()
    {
        Player_God = false;
        Player_Level = 2;
        Player_Hp = Player_MaxHp;
        Player_img = GetComponentInChildren<Image>();
        Player_col = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // 프레임 단위 실행
    private void Update()
    {
        Player_Move();
        Player_Attack();
        Camera_Check();
    }

    // 플레이어 이동 관련 함수
    private void Player_Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 Position = transform.position;

        Position.x += Horizontal * Time.deltaTime * Player_Speed;
        Position.y += Vertical * Time.deltaTime * Player_Speed;

        transform.position = Position;

        if (Horizontal > 0)
        {
            idle.SetActive(false);
            left.SetActive(false);
            right.SetActive(true);
        }
        else if (Horizontal < 0)
        {
            idle.SetActive(false);
            left.SetActive(true);
            right.SetActive(false);
        }
        else
        {
            idle.SetActive(true);
            left.SetActive(false);
            right.SetActive(false);
        }
    }

    // 플레이어 총알 발사 함수
    private void Player_Attack()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            MakeBullet();
        }
    }

    // 플레이어 총알 생성 함수
    private void MakeBullet()
    {
        switch(Player_Level)
        {
            case 1:
                Instantiate(Player_Bullet_Lv1, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                break;
            case 2:
                Instantiate(Player_Bullet_Lv2, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                break;
            case 3:
                Instantiate(Player_Bullet_Lv3, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                break;
            case 4:
                Instantiate(Player_Bullet_Lv4, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                break;
            case 5:
                Instantiate(Player_Bullet_Lv5, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                break;
        }
    }

    // 카메라 범위 체크 함수
    private void Camera_Check()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 1.0f;
        if (pos.x > 1f) pos.x = 0.0f;
        if (pos.y < 0.125f) pos.y = 0.125f;
        if (pos.y > 0.88f) pos.y = 0.88f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    // 충돌판정
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            // 적군,적군총알
            case "1":
                if(!Player_God)
                {
                    Unbeatable();
                }
                break;
            // 아이템
            case "2":
                break;
        }
    }

    // 피격당했을시
    private void Unbeatable()
    {
        Player_God = true;
        Player_img.color = new Color(1, 1, 1, 0.5f);
        Invoke("Onbeatable", 1.5f);
    }

    // 피격 복구
    private void Onbeatable()
    {
        Player_God = false;
        Player_img.color = new Color(1, 1, 1, 1);
    }
}