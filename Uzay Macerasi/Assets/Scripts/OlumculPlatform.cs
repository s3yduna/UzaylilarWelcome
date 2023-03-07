using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlumculPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;

    bool hareket;
    float randomHiz;
    float min, max;
    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomHiz = Random.Range(0.5f, 1.0f);

        float objeGenislik = boxCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objeGenislik;
            max = EkranHesap.instance.Genislik - objeGenislik;
        }
        else
        {
            min = -EkranHesap.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }

 
    void Update()
    {
        if (hareket)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ayaklar")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }
}
