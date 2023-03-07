using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{

    [SerializeField]
    Sprite[] muzikIkonlar = default;

    [SerializeField]
    Button muzikButon = default;


    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KayitVarMi() == false)
        {
            Secenekler.KolayDegerAta(1);
        }

        if(Secenekler.MuzikAcikKayitVarMi() == false)
        {
            Secenekler.MuzikAcikDegerAta(1);
        }
        MuzikAyarlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if (Secenekler.MuzikAcikDegerOku() == 1)
        {
            Secenekler.MuzikAcikDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            Secenekler.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }


    void MuzikAyarlariniDenetle()
    {
        if (Secenekler.MuzikAcikDegerOku() == 1)
        {
            muzikButon.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        }
        else
        {
            muzikButon.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }
}
