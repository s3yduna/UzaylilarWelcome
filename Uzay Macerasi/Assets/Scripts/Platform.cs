using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    PolygonCollider2D polygonCollider2D;

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
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        randomHiz = Random.Range(0.5f, 1.0f);

        if (Secenekler.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);
        }
        if (Secenekler.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.3f);
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(1.1f, 1.6f);
        }


        float objeGenislik = polygonCollider2D.bounds.size.x / 2;

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

    // Update is called once per frame
    void Update()
    {
        if (hareket) 
        {
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ayaklar") 
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
    }
}
