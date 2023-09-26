using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public AudioClip destroySound;
    public int enemyHP;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // もしもぶつかった相手に「Bullet」というタグ（Tag）がついていたら、
        if (other.gameObject.CompareTag("Bullet"))
        {
            // 敵のHPを1ずつ減少させる
            enemyHP -= 1;

            // プレイヤーの弾を削除する
            Destroy(other.gameObject);

            // 敵のHPが0になったら敵オブジェクトを破壊する。
            if (enemyHP <= 0)
            {
                // 敵オブジェクトを破壊する
                Destroy(gameObject);

                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
        }
    }
}