using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    private bool firstPush = false;

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
        if(!firstPush)
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("StageSelectScene");
            firstPush = true;
        }
    }

    public void PlayInStageSelectClick()
    {
        if(!firstPush)
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("PlayScene");
            firstPush = true;
        }
    }
}
