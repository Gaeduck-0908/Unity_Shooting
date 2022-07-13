using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class PlayerManager : Singleton<PlayerManager>
{
    // TODO
    // �÷��̾��� ���� ���� �ڵ� �ۼ� �ٶ�

    // �÷��̾��� ü��
    public int Player_MaxHp = 100;
    public int Player_Hp;

    // �÷��̾��� �ӵ�
    private float Player_Speed = 7f;

    // �÷��̾��� �������
    private bool Player_God;

    // �÷��̾��� ����
    private int Player_Level;

    // �÷��̾��� �Ѿ˰���
    private float fireRate = 0.2f;
    private float nextFire = 0.0f;

    // �÷��̾��� �Ѿ� ������Ʈ
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

    // �÷��̾��� ������Ʈ
    private Image Player_img;
    private Collider2D Player_col;
    private Rigidbody2D rigid;

    public GameObject idle;
    public GameObject left;
    public GameObject right;

    // ���� �ѹ� ����
    private void Start()
    {
        Player_God = false;
        Player_Level = 2;
        Player_Hp = Player_MaxHp;
        Player_img = GetComponentInChildren<Image>();
        Player_col = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // ������ ���� ����
    private void Update()
    {
        Player_Move();
        Player_Attack();
        Camera_Check();
    }

    // �÷��̾� �̵� ���� �Լ�
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

    // �÷��̾� �Ѿ� �߻� �Լ�
    private void Player_Attack()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            MakeBullet();
        }
    }

    // �÷��̾� �Ѿ� ���� �Լ�
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

    // ī�޶� ���� üũ �Լ�
    private void Camera_Check()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 1.0f;
        if (pos.x > 1f) pos.x = 0.0f;
        if (pos.y < 0.125f) pos.y = 0.125f;
        if (pos.y > 0.88f) pos.y = 0.88f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    // �浹����
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            // ����,�����Ѿ�
            case "1":
                if(!Player_God)
                {
                    Unbeatable();
                }
                break;
            // ������
            case "2":
                break;
        }
    }

    // �ǰݴ�������
    private void Unbeatable()
    {
        Player_God = true;
        Player_img.color = new Color(1, 1, 1, 0.5f);
        Invoke("Onbeatable", 1.5f);
    }

    // �ǰ� ����
    private void Onbeatable()
    {
        Player_God = false;
        Player_img.color = new Color(1, 1, 1, 1);
    }
}