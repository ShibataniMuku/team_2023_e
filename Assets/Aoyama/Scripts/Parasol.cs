using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasol : MonoBehaviour
{
    private AudioSource audioSource;

    public ParasolGuard guard;
    public AudioClip get;
    
    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceをコンポーネントから取得
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(get);
            Destroy(this.gameObject);
        }
    }



}
