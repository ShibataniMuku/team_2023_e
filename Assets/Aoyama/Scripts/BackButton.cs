using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
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

    //タイトルシーンへ移行
    public void BackClick()
    {
        audioSource.PlayOneShot(tap);
        Invoke("ToTitle",0.5f);
    }

    void ToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
