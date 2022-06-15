using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class UI_Manager : Singleton<UI_Manager>
{
    // TODO
    // HP 같은 UI 관련 코드 작성 바람

    // 플레이어 HP 표시 텍스트
    public Text Player_HP_text;

    // 프레임 단위로 실행
    private void Update()
    {
        // 체력 받아오기
        string hp = PlayerManager.Instance.Player_Hp.ToString();

        // 텍스트에 적용
        Player_HP_text.text = "HP : " + hp;
    }
}
