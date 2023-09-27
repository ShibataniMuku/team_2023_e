using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
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

    //直前のシーンへ移行するための関数を他スクリプトから呼び出す
    public void RetryClick()
    {
        audioSource.PlayOneShot(tap);
        Invoke("Retry",0.5f);
    }

    void Retry()
    {
        GameOverOrClear.BackToBeforeScene();
    }
}
