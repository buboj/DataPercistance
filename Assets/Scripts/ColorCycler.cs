using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{
    public Material materialUsed;
    public float cycleSpeed = 0.25f;
	public float time = 3.0f;
    public float h, s, v;


	void Start() {
        materialUsed = GetComponentInChildren<Renderer>().material;
        Color.RGBToHSV(materialUsed.color, out h, out s, out v);
	}

	void Update() {
        h += cycleSpeed * Time.deltaTime;
        if (h >= 1){
            h = 0;
        }
        materialUsed.color = Color.HSVToRGB(h, s, v);
	}
}

