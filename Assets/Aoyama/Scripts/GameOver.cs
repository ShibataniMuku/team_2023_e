using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameOver
{
    public static string sceneName;

    public static void CurrentSceneName()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
    }

    // 上記のメソッドで取得されたシーンに戻る。
    // Retryボタンを押した時にこのメソッドを実行する。
    public static void BackToBeforeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
