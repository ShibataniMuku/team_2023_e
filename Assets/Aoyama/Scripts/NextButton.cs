using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //次のシーンへ移行する関数を他スクリプトから呼び出す
    public void NextClick()
    {
        GameOverOrClear.NextScene();
    }
}
