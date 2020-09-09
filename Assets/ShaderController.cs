using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ShaderController : MonoBehaviour
{

    float sensS, cutoffS;
    Color colS;



    void Start()
    {
        sensS = GetComponent<RawImage>().material.GetFloat("_Sens");
        cutoffS = GetComponent<RawImage>().material.GetFloat("_Cutoff");
        colS = GetComponent<RawImage>().material.GetColor("_Color");

        sens = sensS;
        cutoff = cutoffS;
    }


    public float sens, cutoff;
    public string r = "99", g = "205", b = "77";
    void OnGUI()
    {
        sens = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), sens, 0.0f, 1.0f);
        cutoff = GUI.HorizontalSlider(new Rect(25, 70, 100, 30), cutoff, 0.0f, 1.0f);

        r = GUI.TextField(new Rect(25, 120, 40, 20), r);
        g = GUI.TextField(new Rect(70, 120, 40, 20), g);
        b = GUI.TextField(new Rect(120, 120, 40, 20), b);

        if (GUI.Button(new Rect(25, 160, 100, 30), "Reset"))
        {
            sens = sensS;
            cutoff = cutoffS;

            r = (colS.r * 255f).ToString();
            g = (colS.g * 255f).ToString();
            b = (colS.b * 255f).ToString();
        }


        GetComponent<RawImage>().material.SetFloat("_Sens", sens);
        GetComponent<RawImage>().material.SetFloat("_Cutoff", cutoff);
        try
        {
            Color col = new Color(int.Parse(r) / 255f, int.Parse(g) / 255f, int.Parse(b) / 255f);
            //print (col);
            GetComponent<RawImage>().material.color = col;

        }
        catch (UnityException e)
        {
        }
    }
}