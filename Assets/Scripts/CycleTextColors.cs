using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class CycleTextColors : MonoBehaviour
{
    Color topLeft = new Vector4(1f, 0f, 0f, 1f);
    Color topRight = new Vector4(0f, 1f, 0f, 1f);
    Color bottomLeft = new Vector4(0f, 0f, 1f, 1f);
    Color bottomRight = new Vector4(0.5f, 0f, 0.5f, 1f);
    public float cycleSpeed = 2f;

    public TextMeshProUGUI titleText;

    // Start is called before the first frame update
    void Start(){
        titleText = GetComponent<TextMeshProUGUI>();
        titleText.colorGradient = new VertexGradient(topLeft, topRight, bottomLeft, bottomRight);
    }


    Color CycleColor(Color givenColor){
        float h, s, v;
        Color.RGBToHSV(givenColor, out h, out s, out v);
        h += cycleSpeed * Time.deltaTime;
        if (h >= 1){
            h = 0;
        }
        Debug.Log(h);
        return Color.HSVToRGB(h, s, v);
    }

    // Update is called once per frame
    void Update(){
        topRight = CycleColor(topRight);
        topLeft = CycleColor(topLeft);
        bottomLeft = CycleColor(bottomLeft);
        bottomRight = CycleColor(bottomRight);
        titleText.colorGradient = new VertexGradient(topLeft, topRight, bottomLeft, bottomRight);
    }
}
