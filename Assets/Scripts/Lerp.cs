using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 3f;



    public Material mate;
    public Light light;
    // Use this for initialization
    void Start()
    {
        mate = this.GetComponent<LineRenderer>().material;
        light = this.GetComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {

        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        mate.color = Color.Lerp(colorStart, colorEnd, lerp);
        mate.SetColor("_EmissionColor", mate.color);
        light.color = mate.color;



    }
}
