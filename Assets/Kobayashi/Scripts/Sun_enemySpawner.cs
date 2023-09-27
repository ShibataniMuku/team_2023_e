using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のプレハブ
    private float spawnInterval = 10.0f; // 敵を生成する間隔（秒）
    private Vector3 spawnPosition; // 生成位置の範囲

    void Start()
    {
        // 18秒後に敵生成を開始
        InvokeRepeating("SpawnRandomEnemy", 5.0f, spawnInterval);
        
        // 生成位置の範囲を設定
        spawnPosition = new Vector3(2, Random.Range(4f, 0f), 0f);
    }

    // ランダムな位置に敵を生成するメソッド
    void SpawnRandomEnemy()
    {
        // 敵のプレハブをランダムな位置に生成
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}