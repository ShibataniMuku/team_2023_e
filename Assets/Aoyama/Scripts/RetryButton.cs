using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //直前のシーンへ移行するための関数を他スクリプトから呼び出す
    public void RetryClick()
    {
        GameOverOrClear.BackToBeforeScene();
    }
}
