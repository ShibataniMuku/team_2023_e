using UnityEngine;

public class damage_animation : MonoBehaviour
{
    private Animator animator;
    public int enemyHP; // 敵のHP
    public AudioClip destroySound;

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
            }

            // 敵オブジェクトを破壊する
            Destroy(gameObject, 0.5f);
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
        }
    }
}