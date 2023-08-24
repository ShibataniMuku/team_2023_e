using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UTF-8...
public class MakeFloor : MonoBehaviour{
    public GameObject FloorPrefab;
    void Start(){
        int i, j, rnd1, rnd2;
        for(i = 0; i < 100; i++){
            // 床の場所決め...
            bool[] ExistFloor = new bool[10];
            do{
                rnd1 = Random.Range(0, 10);
                rnd2 = Random.Range(0, 10);
                for(j = Mathf.Min(rnd1, rnd2); j <= Mathf.Max(rnd1, rnd2); j++){
                    ExistFloor[j] = true;
                }
            }while(Random.Range(0, 10) == 0);
            // 床設置...
            for(j = 0; j <= 9; j++){
                if(ExistFloor[j]){
                    Instantiate(FloorPrefab, new Vector3(j * 0.6f - 2.7f, i * 2, 0), Quaternion.identity);
                }
            }
        }
    }
}