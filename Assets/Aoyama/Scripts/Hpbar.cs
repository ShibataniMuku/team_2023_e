using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hpbar : MonoBehaviour
{
    //Sliderコーポネントを管理する用
    Slider HPbar;
    //HPを定義
    public int HP = 100;

    //現在の時間
    private float currentTime = 0f;
 
    // Start is called before the first frame update
    void Start()
    {
        //HPバーを取得
        HPbar = GameObject.Find("Hpbar").GetComponent<Slider>();

        //HPバーの最大値をHPにする
        HPbar.maxValue = HP;
         
        //HPの初期値を100に
        HPbar.value = 100;
    }
 
    // Update is called once per frame
    void Update()
    {
        //前のフレームから経過した秒数を加算
        currentTime += Time.deltaTime;
 
        //2秒毎に処理を行う
        if(currentTime >= 2.0f)
        {
            HPbar.value += -1;
            currentTime = 0;
        }

        //Hpが0になるとゲームオーバー
        if(HPbar.value == 0)
        {
            GameOverOrClear.CurrentSceneName();
            SceneManager.LoadScene("GameOver");
            Debug.Log("ゲームオーバー");
        }
    }

    //Hpが減る
    public void CollisionDamage()
    {
        HPbar.value += -2;
    }

    public void BardDamage()
    {
        HPbar.value += -1;
    }

    public void FlowerDamage()
    {
        HPbar.value += -3;
    }

    public void FrameDamage()
    {
        HPbar.value += -5;
    }

    public void UVDamage()
    {
        HPbar.value += -2;
    }

    public void BossDamage()
    {
        HPbar.value += -5;
    }

    //Hpが回復する
    public void Heal()
    {
        HPbar.value += 30;
    }
}
