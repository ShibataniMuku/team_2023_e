using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_frameenemy_attack : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;

    private Animator anim;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

        // 通常の状態
        if (currentState.IsName("idle"))
        {
            if (timer > interval)
            {
                // 攻撃を3方向に実行
                AttackThreeWay();
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    // 攻撃を3方向に実行
    private void AttackThreeWay()
    {
        // 現在の敵の位置と回転を取得
        Vector3 enemyPosition = transform.position;
        Quaternion enemyRotation = transform.rotation;

        // 攻撃を3方向に生成
        for (int i = -1; i <= 1; i++)
        {
            GameObject g = Instantiate(attackObj);
            g.transform.SetParent(transform);
            g.transform.position = enemyPosition;
            
            // 各方向に対する回転を計算
            Quaternion newRotation = enemyRotation * Quaternion.Euler(0, 0, i * 15f); // 15度ずつ変更
            g.transform.rotation = newRotation;
            g.SetActive(true);
        }
    }
}