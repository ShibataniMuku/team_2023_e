using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasol : MonoBehaviour
{
    public ParasolGuard guard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //parasolを取るとGuard()を呼び出す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            guard.Guard();
            Destroy(this.gameObject);
        }
    }



}
