using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class UI_Manager : Singleton<UI_Manager>
{
    // TODO
    // HP ���� UI ���� �ڵ� �ۼ� �ٶ�

    // �÷��̾� HP ǥ�� �ؽ�Ʈ
    public Text Player_HP_text;

    // ������ ������ ����
    private void Update()
    {
        // ü�� �޾ƿ���
        string hp = PlayerManager.Instance.Player_Hp.ToString();

        // �ؽ�Ʈ�� ����
        Player_HP_text.text = "HP : " + hp;
    }
}
