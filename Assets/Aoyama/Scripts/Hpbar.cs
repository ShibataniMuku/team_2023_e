using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    //Sliderコーポネントを管理する用
    Slider HPbar;
    //HPを定義
    public int HP = 100;

    bool GameOver = false;
 
    //現在の時間
    private float currentTime = 0f;
 
    // Start is called before the first frame update
    void Start()
    {
        //HPバーを取得
        HPbar = GameObject.Find("Hpbar").GetComponent<Slider>();
        //HPバーの最大値をHPにする
        HPbar.maxValue = HP;
         
        //HPの初期値を0に
        HPbar.value = 100;
    }
 
    // Update is called once per frame
    void Update()
    {
        //前のフレームから経過した秒数を加算
        currentTime += Time.deltaTime;
 
        //毎秒処理を行う
        if(currentTime >= 2.0f)
        {
            HPbar.value += -1;
            currentTime = 0;
        }

        if(HPbar.value == 0 && GameOver == false)
        {
            GameOver = true;
            Debug.Log("ゲームオーバー");
        }
    }

    public void Damage()
    {
        HPbar.value += -50;
    }
}