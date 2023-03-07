using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{

    float hiz;
    float hizlanma;
    float maksimumHiz;

    bool hareket = true;

    void Start()
    {

        if (Secenekler.KolayDegerOku() == 1)
        {
            hiz = 0.5f;
            hizlanma = 0.05f;
            maksimumHiz = 2.0f;
        }
        if (Secenekler.OrtaDegerOku() == 1)
        {
            hiz = 1.0f;
            hizlanma = 0.1f;
            maksimumHiz = 4.0f;
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            hiz = 2.0f;
            hizlanma = 0.3f;
            maksimumHiz = 6.0f;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket) 
        {
            KamerayiHareketEttir();
        }
    }

    void KamerayiHareketEttir() 
    {
        transform.position += transform.up * hiz * Time.deltaTime;
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maksimumHiz) 
        {
            hiz = maksimumHiz;
        }
    }
}
