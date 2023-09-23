using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//静的スクリプト
public static class GameOverOrClear
{
    public static string sceneName;

    //現在のシーン名を読み込む
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

    //現在のステージに合わせて次のステージに移行
    public static void NextScene()
    {
        if(sceneName == "PlayScene_t")
        {
            SceneManager.LoadScene("PlayScene_u");
        }
        if(sceneName == "PlayScene_u")
        {
            SceneManager.LoadScene("PlayScene_s");
        }
        if(sceneName == "PlayScene_s")
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
