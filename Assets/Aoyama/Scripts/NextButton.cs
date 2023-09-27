using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    private AudioSource audioSource;

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

    //次のシーンへ移行する関数を他スクリプトから呼び出す
    public void NextClick()
    {
        audioSource.PlayOneShot(tap);
        Invoke("Next",0.5f);
    }

    void Next()
    {
        GameOverOrClear.NextScene();
    }
}
