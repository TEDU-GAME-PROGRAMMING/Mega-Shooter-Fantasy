using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //references
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    

    //variable

    [SerializeField] float D_NCycleDuration = 1200;
    [SerializeField, Range(0, 1200)] private float TimeOfDay;
    public static bool isDay = false;



    private void Update()
    {
        if(TimeOfDay > (D_NCycleDuration/4) && TimeOfDay < 3 * (D_NCycleDuration / 4))
        {
            isDay = true;
        }
        else{
            isDay = false;
        }

        if(Preset == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= D_NCycleDuration;
            UpdateLighting(TimeOfDay / D_NCycleDuration);
        }
        else
        {
            UpdateLighting(TimeOfDay / D_NCycleDuration);
        }
    }


    private void UpdateLighting(float timePercent)
    {

        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        //map to 0 - 3.14

        DirectionalLight.intensity = Mathf.Sin(Mathf.PI * timePercent) - 0.2f;

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }


    }

    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            //Plural form of objects
            Light[] lights =  GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                DirectionalLight = light;
                return;
            }
        }
        




    }


}
