using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ayaklar")
        {
            GetComponentInParent<Altin>().AltinKapat();
            FindObjectOfType<Puan>().AltinKazan();
        }
    }
}
