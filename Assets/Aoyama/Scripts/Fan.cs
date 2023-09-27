using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private AudioSource audioSource;

    public Hpbar heal;
    public PlayerController waterHeal;
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

    //fanを取るとHeal()を呼び出す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            heal.Heal();
            waterHeal.WaterHeal();
            Destroy(this.gameObject);
            audioSource.PlayOneShot(get);
        }
    }
}
