using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuanKontrol : MonoBehaviour
{

    public Text kolayPuan, kolayAltin, ortaPuan, ortaAltin, zorPuan, zorAltin;

    void Start()
    {

        kolayPuan.text = "Puan : " + Secenekler.KolayPuanDegerOku();
        kolayAltin.text = " x" + Secenekler.KolayAltinDegerOku();

        ortaPuan.text = "Puan : " + Secenekler.OrtaPuanDegerOku();
        ortaAltin.text = " x" + Secenekler.OrtaAltinDegerOku();

        zorPuan.text = "Puan : " + Secenekler.ZorPuanDegerOku();
        zorAltin.text = " x" + Secenekler.ZorAltinDegerOku();

    }

   

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
