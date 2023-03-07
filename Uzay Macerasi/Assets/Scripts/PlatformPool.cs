using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject olumculPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPozisyon;
    Vector2 playerPozisyon;

    [SerializeField]
    float platfomArasiMesafe = default;
    void Start()
    {
        PlatformUret();
    }

    // Update is called once per frame
    void Update()
    {
        if(platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + EkranHesap.instance.Yukseklik) 
        {
            PlatformYerlestir();
        }
    }

    void SonrakiPlatformPozisyon()
    {
        platformPozisyon.y += platfomArasiMesafe;
        SiraliPozisyon();
    }

    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        playerPozisyon = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
        platforms.Add(ilkPlatform);
        SonrakiPlatformPozisyon();
        ilkPlatform.GetComponent<Platform>().Hareket = false;

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatformPozisyon();
        }

        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozisyon, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiPlatformPozisyon();

    }

    void PlatformYerlestir() 
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPozisyon;
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Altin>().AltinKapat();
                float rastgeleAltin = Random.Range(0.0f, 1.0f);
                if(rastgeleAltin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();

                }
            }
            SonrakiPlatformPozisyon();
        }

        

    }
    /*KARMA PLATFORM POZÝSYONLARI ÝÇÝN KOD SATIRI*/
    void KarmaPozisyon()
    {
        platformPozisyon.y += platfomArasiMesafe;
        float random = Random.Range(0.0f, 1.0f);

        if (random < 0.5f)
        {
            platformPozisyon.x = EkranHesap.instance.Genislik / 2;
        }
        else
        {
            platformPozisyon.x = -EkranHesap.instance.Genislik / 2;
        }
    }

    /*BÝR SAÐ BÝ SOL OLMAK ÜZERE DÜZENLÝ PLATFORM POZÝSYONLARI ÝÇÝN KOD SATIRI*/
    bool yon = true;
    void SiraliPozisyon()
    {
        if (yon)
        {
            platformPozisyon.x = EkranHesap.instance.Genislik / 2;
            yon = false;
        }
        else
        {
            platformPozisyon.x = -EkranHesap.instance.Genislik / 2;
            yon = true;
        }
    }
}
