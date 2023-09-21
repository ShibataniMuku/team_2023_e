using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderFloor : MonoBehaviour{
    // 床を描画...
    BoxCollider2D bc;
    public GameObject FloorLeft;
    public GameObject FloorMiddle;
    public GameObject FloorRight;
    void Start(){
        bc = GetComponent<BoxCollider2D>();
        // スケール取得...
        float width = transform.size.x;
        // spriteに合わせるため幅を0.5単位に丸める...
        width = width < 0.5f ? 0.5f : Mathf.Round(width * 2) / 2;
        // スケールを1,1,1に...
        transform.size = Vector3.one;
        // SpriteRenderer消す...
        GetComponent<SpriteRenderer>().enabled = false;
        // 当たり判定を変更...
        bc.size = new Vector2(width, 0.4);

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
