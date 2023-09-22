using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderFloor : MonoBehaviour{
    // 床を描画...
    public GameObject FloorLeft;
    public GameObject FloorMiddle;
    public GameObject FloorRight;
    void Start(){
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        // スケール取得...
        float width = transform.localScale.x;
        // spriteに合わせるため幅を0.5単位に丸める...
        width = width < 0.5f ? 0.5f : Mathf.Round(width * 2) / 2;
        // スケールを1,1,1に...
        transform.localScale = Vector3.one;
        // SpriteRenderer消す...
        sr.enabled = false;
        // 当たり判定を変更...
        bc.size = new Vector2(width, 0.4f);

        // spriteを描画...
        for(int i = 0; i <= width * 2; i++){
            // 足場のprefabを複製...
            GameObject obj = Instantiate(
                i == 0 ? FloorLeft : i == width * 2 ? FloorRight : FloorMiddle,
                Vector3.zero,
                Quaternion.identity
            );
            // 子要素にする...
            obj.transform.SetParent(gameObject.transform);
            // 位置決定...
            obj.transform.localPosition = new Vector3((i - width) * 0.5f, 0f, 0f);
        }
    }
}
