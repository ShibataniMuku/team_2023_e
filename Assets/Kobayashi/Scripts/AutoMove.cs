using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private float MoveSpeedX = 1.75f;
    private float MoveDistanceY = -0.15f; // 1秒かけて移動する距離
    private Vector3 initialPosition;
    private float timerY = 0f;
    private bool movingDownY = false;
    private bool waitingY = false;
    private float waitTimer = 0f;
    private float waitDuration = 3f; // 上での待機時間（1秒に設定）
    private bool isDead = false;    // 敵が倒れたかどうかのフラグ
    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
             Debug.Log("Rigidbody2D コンポーネントが見つかりません。");
             // エラー処理などを追加するか、適切な対処方法を考えてください。
        }
        initialPosition = transform.position;
    }

    void Update()
    {
        if(!isDead)
        {
            // x軸の動き（サイン波）
            float xPosition = Mathf.Sin(Time.time) * MoveSpeedX;
            Vector3 newPosition = new Vector3(xPosition, transform.position.y, 0f);
            transform.position = newPosition;

            // y軸の動き
            if (!waitingY)
            {
                timerY += Time.deltaTime;
    
                if (movingDownY)
                {
                    transform.Translate(Vector3.down * Time.deltaTime / MoveDistanceY);

                    if (timerY >= 1f)
                    {
                        timerY = 0f;
                        movingDownY = false;
                        waitingY = true;
                    }
                }
                else
                {
                    transform.Translate(Vector3.up * Time.deltaTime / MoveDistanceY);

                    if (timerY >= 1f)
                    {
                        timerY = 0f;
                        movingDownY = true;
                    }
                }
            }
            else
            {
                waitTimer += Time.deltaTime;

                if (waitTimer >= waitDuration)
                {
                    waitTimer = 0f;
                    waitingY = false;
                }
            }
        } 
        else
        {
            // 敵が倒れたら移動を停止する
            rb.velocity = Vector3.zero;
        }
    }

    public void SetDead(bool dead)
    {
        isDead = dead;
    }
}