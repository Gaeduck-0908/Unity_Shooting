using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // TODO
    // �÷��̾��� �Ѿ� ���� �ڵ� �ۼ��ٶ� 

    // �Ѿ��� ������
    public int Bullet_dmg_Lv1 = 5;
    public int Bullet_dmg_Lv2 = 10;
    public int Bullet_dmg_Lv3 = 20;
    public int Bullet_dmg_Lv4 = 50;
    public int Bullet_dmg_Lv5 = 100;

    // �Ѿ��� ���ǵ�
    public float Bullet_Speed = 10.0f;

    // �����Ӵ��� ����
    private void Update()
    {
        Bullet_move();
    }

    // �Ѿ� ������
    private void Bullet_move()
    {
        transform.Translate(Vector3.up * Bullet_Speed * Time.deltaTime);
    }

    // ȭ������� ������
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    // �Ѿ��� �浹����
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.tag)
        {
            case "Enemy":
                Destroy(this.gameObject);
                break;
        }
    }
}
