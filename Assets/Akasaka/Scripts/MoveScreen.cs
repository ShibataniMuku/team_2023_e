using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class MoveScreen : MonoBehaviour
{
    public GameObject Player;
    float Height = 1.75f;
    void Update(){
        transform.position = new Vector3 (0f, Player.transform.position.y + Height, transform.position.z);
    }
}
