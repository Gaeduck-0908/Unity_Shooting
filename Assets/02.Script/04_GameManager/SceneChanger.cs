using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lib;

public class SceneChanger : Singleton<SceneChanger>
{
    // TODO
    // 씬관련 코드 작성바람

    // Title 씬로드 함수
    public void Load0Scene()
    {
        SceneManager.LoadScene(0);
    }

    // Lobby 씬로드 함수
    public void Load1Scene()
    {
        SceneManager.LoadScene(1);
    }

    // Stage1 씬로드 함수
    public void Load2Scene()
    {
        SceneManager.LoadScene(2);
    }

    // Stage2 씬로드 함수
    public void Load3Scene()
    {
        SceneManager.LoadScene(3);
    }

    // Score 씬로드 함수
    public void Load4Scene()
    {
        SceneManager.LoadScene(4);
    }
}
