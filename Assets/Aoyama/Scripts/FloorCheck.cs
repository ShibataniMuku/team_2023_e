using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    private string floorTag = "Floor";
    private bool isFloor = false;
    private bool isFloorEnter,isFloorStay,isFloorExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //接地判定を返す
    public bool IsFloor()
    {
       if(isFloorEnter || isFloorStay)
       {
          isFloor = true;
       }
       else if(isFloorExit)
       {
          isFloor = false;
       } 

       isFloorEnter = false;
       isFloorStay = false;
       isFloorExit = false;
       return isFloor; 
    }
 
    //接地判定が入った
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == floorTag)
       {
          isFloorEnter = true;
       }
    }
 
    //接地判定が入り続けている
    private void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.tag == floorTag)
       { 
          isFloorStay = true;
       }
    }
     
    //接地判定が出た
    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.tag == floorTag)
       {
          isFloorExit = true;
       }
    }
}
