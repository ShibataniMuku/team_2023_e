using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject Camera;
    public AudioClip tap;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //タイトル画面からステージセレジト画面への移行
    public void PlayInTitleClick()
    {
        Invoke("SceneInTitle",0.5f);
        audioSource.PlayOneShot(tap);
    }

    void SceneInTitle()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    //ステージセレジト画面からプレイ画面への移行
    public void PlayInStageSelectClick()
    {
        Invoke("InStageSelect",0.5f);
        audioSource.PlayOneShot(tap);
    }

    void InStageSelect()
    {
        if(Camera.transform.position.x == 0)
        {
            SceneManager.LoadScene("PlayScene_t");
        }
        else if(Camera.transform.position.x == 5)
        {
            SceneManager.LoadScene("PlayScene_u");
        }
        else if(Camera.transform.position.x == 10)
        {
            SceneManager.LoadScene("PlayScene_s");
        }
    }
}
