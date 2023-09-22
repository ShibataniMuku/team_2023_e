using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //タイトル画面からステージセレジト画面への移行
    public void PlayInTitleClick()
    {
            Debug.Log("NextScene");
            SceneManager.LoadScene("StageSelectScene");
    }

    //ステージセレジト画面からプレイ画面への移行
    public void PlayInStageSelectClick()
    {
        //カメラの位置xが0なら（背景が都会ステージなら）
        if(Camera.transform.position.x == 0)
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("PlayScene_t");
        }
        //カメラの位置xが5なら（背景が宇宙ステージなら）
        else if(Camera.transform.position.x == 5)
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("PlayScene_u");
        }
        //カメラの位置xが10なら（背景が太陽ステージなら）
        else if(Camera.transform.position.x == 10)
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("PlayScene_s");
        }
    }
}
