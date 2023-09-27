using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip tap;
    public GameObject RightArrow;
    public GameObject LeftArrow;

    // Start is called before the first frame update
    void Start()
    {
        //最初の位置を固定
        this.transform.position = new Vector3(0,0,-10);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの位置xが0（都会ステージが映っていたら）LeftArrowを非表示に
        if(this.transform.position.x == 0)
        {
            LeftArrow.SetActive(false);
        }
        else
        {
            LeftArrow.SetActive(true);
        }

        if(this.transform.position.x == 10)
        {
            RightArrow.SetActive(false);
        }
        //カメラの位置xが0（太陽ステージが映っていたら）RightArrowを非表示に
        else
        {
            RightArrow.SetActive(true);
        }

    }

    //カメラをステージ選択のために右に移動
    public void RightArrowClick()
    {
        this.transform.position = new Vector3(this.transform.position.x + 5,0,-10);
        audioSource.PlayOneShot(tap);
    }

    //カメラをステージ選択のために左に移動
    public void LeftArrowClick()
    {
        this.transform.position = new Vector3(this.transform.position.x + -5,0,-10);
        audioSource.PlayOneShot(tap);
    }
}
