using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_HP : MonoBehaviour
{
    private Animator animator;
    public int enemyHP; // 敵のHP
    public AudioClip bulletHitSound; // Bulletが当たったときのサウンド
    public AudioClip destroySound;
    public GameObject BGM;

    private AudioSource audioSource;
    private bool isDestroyed = false; // 破壊済みフラグ
    private bool hasPlayedSound = false; // サウンド再生フラグ


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 敵のHPが特定の値以下になった場合、条件を設定
        if (enemyHP <= 0 && !isDestroyed)
        {
            animator.SetInteger("HP", 0);
            isDestroyed = true; // 破壊済みフラグを立てる
            BGM.SetActive(false);

            if (!hasPlayedSound)
            {
                // サウンド再生
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
                hasPlayedSound = true; // サウンド再生フラグを立てる

                Invoke("Clear",3f);
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

    private void Clear()
    {
        Debug.Log("%");
        SceneManager.LoadScene("GameClear");
        GameOverOrClear.CurrentSceneName();
        
    }
}