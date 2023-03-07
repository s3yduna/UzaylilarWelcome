using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareket : MonoBehaviour
{


    float arkaPlanKonum;
    float mesafe = 10.24f;

    void Start()
    {
        arkaPlanKonum = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (arkaPlanKonum + mesafe < Camera.main.transform.position.y) 
        {
            ArkaplanYerlestir();
        }
    }


    void ArkaplanYerlestir() 
    {
        arkaPlanKonum += (mesafe * 2);
        Vector2 yeniPozisyon = new Vector2(0, arkaPlanKonum);
        transform.position = yeniPozisyon;
    }
}
