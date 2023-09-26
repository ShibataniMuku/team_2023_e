using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_HP : MonoBehaviour
{
    private Animator animator;
    public int enemyHP; // 敵のHP
    public AudioClip bulletHitSound; // Bulletが当たったときのサウンド
    public AudioClip destroySound;
    public AudioClip otherSound; // 別のサウンド

    private bool isDestroyed = false; // 破壊済みフラグ
    private bool hasPlayedSound = false; // サウンド再生フラグ

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 敵のHPが特定の値以下になった場合、条件を設定
        if (enemyHP <= 0 && !isDestroyed)
        {
            animator.SetInteger("HP", 0);
            isDestroyed = true; // 破壊済みフラグを立てる

            if (!hasPlayedSound)
            {
                // サウンド再生
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
                hasPlayedSound = true; // サウンド再生フラグを立てる

                // 別のサウンドを再生するためのコルーチンを開始
                StartCoroutine(PlayOtherSoundAfterDelay(3.0f)); // 3秒後に再生
            }

            // 敵オブジェクトを破壊する
            Destroy(gameObject, 3.0f);

            // 敵の死亡フラグを立てる
            GetComponent<AutoMove>().SetDead(true);
        }
        else
        {
            animator.SetInteger("HP", 1);
        }
    }

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
        }
    }

    // 指定の遅延時間後に別のサウンドを再生するコルーチン
    private IEnumerator PlayOtherSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioSource.PlayClipAtPoint(otherSound, transform.position);
    }
}