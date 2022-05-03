using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lib;

public class SceneChanger : Singleton<SceneChanger>
{
    // TODO
    // ������ �ڵ� �ۼ��ٶ�

    // Title ���ε� �Լ�
    public void Load0Scene()
    {
        SceneManager.LoadScene(0);
    }

    // Lobby ���ε� �Լ�
    public void Load1Scene()
    {
        SceneManager.LoadScene(1);
    }

    // Stage1 ���ε� �Լ�
    public void Load2Scene()
    {
        SceneManager.LoadScene(2);
    }

    // Stage2 ���ε� �Լ�
    public void Load3Scene()
    {
        SceneManager.LoadScene(3);
    }

    // Score ���ε� �Լ�
    public void Load4Scene()
    {
        SceneManager.LoadScene(4);
    }
}
