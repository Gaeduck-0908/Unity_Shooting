using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    // TODO
    // �÷��̾��� �Ѿ� ���� �ڵ� �ۼ��ٶ� 

    // �Ѿ��� ������
    public int Bullet_dmg_Lv1;
    public int Bullet_dmg_Lv2;
    public int Bullet_dmg_Lv3;
    public int Bullet_dmg_Lv4;
    public int Bullet_dmg_Lv5;

    // �Ѿ��� ���ǵ�
    public float Bullet_Speed = 10.0f;

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
            default:
                Destroy(this.gameObject);
                break;
        }
    }
}
