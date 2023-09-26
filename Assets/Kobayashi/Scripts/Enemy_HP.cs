using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public AudioClip bulletHitSound; // Bulletが当たったときのサウンド
    public AudioClip destroySound;   // 敵が破壊されたときのサウンド
    public int enemyHP;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // もしもぶつかった相手に「Bullet」というタグ（Tag）がついていたら、
        if (other.gameObject.CompareTag("Bullet"))
        {
            // 敵のHPを１ずつ減少させる
            enemyHP -= 1;

            // プレイヤーの弾を削除する
            Destroy(other.gameObject);

            // Bulletが当たったときのサウンドを再生
            AudioSource.PlayClipAtPoint(bulletHitSound, transform.position);

            // 敵のHPが０になったら敵オブジェクトを破壊する。
            if (enemyHP <= 0)
            {
                // 敵オブジェクトを破壊する
                Destroy(gameObject);

                // 敵が破壊されたときのサウンドを再生
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
        }
    }
}