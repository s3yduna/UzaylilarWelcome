using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkrandaTut : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
     if (transform.position.x < -EkranHesap.instance.Genislik)
        {
            Vector2 temp = transform.position;
            temp.x = -EkranHesap.instance.Genislik;
            transform.position = temp;
        }
        if (transform.position.x > EkranHesap.instance.Genislik)
        {
            Vector2 temp = transform.position;
            temp.x = EkranHesap.instance.Genislik;
            transform.position = temp;
        }
    }
}
