using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class MoveCamera : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.position = new Vector3 (0f, Player.transform.position.y + 2.4f, -10f);
    }
}
