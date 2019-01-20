using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

using System.Collections;

public class kayıtDüzenleyici: MonoBehaviour
{

    [Header("Vektör3")]
    public GameObject[] cisimler;
    public String[] pozisyonlar;

    void DosyaYarat()
    {
        if (!File.Exists(Application.dataPath + "/Save/Pozisyonlar.txt"))
        {
            var x = File.Create(Application.dataPath + "/Save/Pozisyonlar.txt");
            x.Dispose();
            x.Close();
        }




    }

    void Start()
    {
        Directory.CreateDirectory(Application.dataPath + "/Save");
        DosyaYarat();
        Oku();

    }

    public void GenelKaydet()
    {
        Kaydet();
    }

    public void GenelYükle()
    {
        Oku();
    }

    public void Çık()
    {
        Application.Quit();
    }



    public void Oku()
    {
        string word = File.ReadAllText(Application.dataPath + "/Save/Pozisyonlar.txt");
        pozisyonlar = word.Split('|');
        VektöreÇevir();

    }

    public void Kaydet()
    {
        List<string> virgüllüVektörList = new List<string>();
        foreach (GameObject cisim in cisimler)
        {
            List<string> Fl = new List<string>();
            
            Fl.Add(Mathf.RoundToInt(cisim.transform.position.x).ToString());
            Fl.Add(Mathf.RoundToInt(cisim.transform.position.y).ToString());
            Fl.Add(Mathf.RoundToInt(cisim.transform.position.z).ToString());

            string[] flA = Fl.ToArray();

            string virgüllüVector = string.Join(",", flA);
            virgüllüVektörList.Add(virgüllüVector);

            if(virgüllüVektörList.Count == cisimler.Length)
            {
                VektörBirleştir(virgüllüVektörList);
            }
        }
    }


    public void VektörBirleştir(List<string> vvl)
    {
        String[] vvlA = vvl.ToArray();

        string yazılacak = string.Join("|", vvlA);

        var sr = File.CreateText(Application.dataPath + "/Save/Pozisyonlar.txt");
        sr.WriteLine(yazılacak);
        sr.Dispose();


        sr.Close();

        Debug.Log(File.ReadAllText(Application.dataPath + "/Save/Pozisyonlar.txt"));

    }



    private void Update()
    {


    }



    public void VektöreÇevir()
    {

        List<List<string>> StringListList = new List<List<string>>();
        List<Vector3> vektörler = new List<Vector3>();
        foreach (string pozisyon in pozisyonlar)
        {
            
            List<string> stringList = new List<string>();
            string[] Eksen = new string[2];
            Eksen = pozisyon.Split(',');
            foreach(string eksen in Eksen)
            {
                stringList.Add(eksen);
            }
            StringListList.Add(stringList);

            if (StringListList.Count == pozisyonlar.Length)
            {
                foreach (List<string> list in StringListList)
                {
                    List<float> Fl = new List<float>();

                    foreach (string x in list)
                    {
                        float f = new float();
                        f = float.Parse(x);
                        Fl.Add(f);
                    }
                    Vector3 eksen = new Vector3(Fl[0], Fl[1], Fl[2]);
                    vektörler.Add(eksen);

                }
            }

        }

        for (int i = 0; i < cisimler.Length; i++)
        {
            cisimler[i].transform.position = vektörler[i];
        }

    }
}