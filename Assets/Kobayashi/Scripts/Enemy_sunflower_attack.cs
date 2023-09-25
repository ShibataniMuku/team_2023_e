using UnityEngine;

public class Enemy_sunflower_attack : MonoBehaviour
{
    public GameObject lazer;
    public Transform attackPoint;
    public float attackInterval = 2.0f; // 攻撃の間隔（秒）
    
    private float attackTimer = 0f;

    void Start()
    {
        attackTimer = attackInterval; // 最初の攻撃を許可するためにタイマーを初期化
    }

    void Update()
    {
        // タイマーを更新
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            Attack(); // 攻撃する条件が満たされたら攻撃
            attackTimer = 0f; // タイマーをリセット
        }
    }

    void Attack()
    {
        // 攻撃処理
        Instantiate(lazer, attackPoint.position, Quaternion.identity);
    }
}