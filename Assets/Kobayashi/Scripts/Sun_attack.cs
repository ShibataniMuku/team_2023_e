using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_attack : MonoBehaviour
{
    [Header("発射するオブジェクト1")] public GameObject objectToLaunch1;
    [Header("発射するオブジェクト2")] public GameObject objectToLaunch2;
    [Header("発射速度")] public float launchSpeed = 10.0f;
    [Header("最初の発射までの待機時間（秒）")] public float initialLaunchDelay = 3.5f;
    [Header("発射間隔（秒）")] public float launchInterval = 10.0f;

    private float timeSinceLastLaunch = 0.0f;
    private bool initialLaunchCompleted = false;
    private bool launchObject1Next = true; // 次に発射するのがオブジェクト1かどうか

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitialLaunchCoroutine());
    }

    IEnumerator InitialLaunchCoroutine()
    {
        yield return new WaitForSeconds(initialLaunchDelay);
        initialLaunchCompleted = true;
        LaunchObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (initialLaunchCompleted)
        {
            // 時間計測
            timeSinceLastLaunch += Time.deltaTime;

            // 10秒ごとにオブジェクトを発射
            if (timeSinceLastLaunch >= launchInterval)
            {
                LaunchObject();
                timeSinceLastLaunch = 0.0f; // タイマーをリセット
            }
        }
    }

    // オブジェクトを発射する関数
    void LaunchObject()
    {
        if (launchObject1Next)
        {
            Launch(objectToLaunch1);
        }
        else
        {
            Launch(objectToLaunch2);
        }

        launchObject1Next = !launchObject1Next; // 次に発射するオブジェクトを切り替える
    }

    void Launch(GameObject objectToLaunch)
    {
        if (objectToLaunch != null)
        {
            // 発射する位置はこのオブジェクトの位置に設定
            Vector3 launchPosition = transform.position;

            // オブジェクトを発射する向きは下方向に設定
            Vector3 launchDirection = Vector3.down;

            // オブジェクトを生成し、速度を設定して発射
            GameObject launchedObject = Instantiate(objectToLaunch, launchPosition, Quaternion.identity);
            Rigidbody2D rb = launchedObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = launchDirection * launchSpeed;
            }
            else
            {
                Debug.LogWarning("発射するオブジェクトにRigidbody2Dがアタッチされていません。");
            }
        }
        else
        {
            Debug.LogWarning("発射するオブジェクトが設定されていません。");
        }
    }
}