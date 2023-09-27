using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 一応キーボードでも動かせるようにする...
public class KeyOperation : MonoBehaviour
{
    public PlayerController PlayerController;
    void Update(){
        // 左移動 = 左矢印キー...
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            PlayerController.LPushDown();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            PlayerController.LPushUp();
        }
        // 右移動 = 右矢印キー...
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            PlayerController.RPushDown();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            PlayerController.RPushUp();
        }
        // ジャンプ = Zキー...
        if(Input.GetKeyDown(KeyCode.Z)){
            PlayerController.JumpClick();
        }
        // 攻撃 = Xキー...
        if(Input.GetKeyDown(KeyCode.X)){
            PlayerController.AttackDown();
        }
    }
}
