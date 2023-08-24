using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour{
    public GameObject Player;
    public float MoveRate;
    void FixedUpdate(){
        float PlayerPosY = Player.transform.position.y;
        float CameraPosY = transform.position.y;
        CameraPosY = CameraPosY * MoveRate + (PlayerPosY + 1.6f) * (1 - MoveRate);
        transform.position = new Vector3 (0, CameraPosY, -10);
    }
}