using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class UnderWaterPostProcessing : MonoBehaviour
{
    //[SerializeField] private PostProcessVolume underWaterEffectProcess;

    public PostProcessVolume postVolume;
    [SerializeField] private LensDistortion lensDis;

    //[SerializeField] private GameObject underwaterobject;
    [SerializeField] private Sualti sualti;

    //public FloatParameter intensityX;
    private float _t = 0.0f;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    public float intensityMin = -10.0F;
    public float intensityMax = -10.0F;

     private void Start()
     {
         
         /*t = Random.Range(0.01f, 0.03f);
         PostVolume.profile.TryGetSettings(out lensdis);
         lensdis.intensity.value = Mathf.Clamp(0,-20,20);
         lensdis.intensity.value = 20.0f;
         lensdis.intensityX.value = 0.5f;
         lensdis.intensityY.value = 0.5f;
         lensdis.centerX.value = Mathf.Clamp(-1, 1);
         lensdis.centerY.value = Mathf.Clamp(-1, 1);
         lensdis.intensity.value= Mathf.Lerp(-1, 1, 0.1f * Time.deltaTime);
         postpro = underwaterobject.GetComponentInParent<PostProcessVolume>();
         lensdis = underwaterobject.GetComponent<LensDistortion>();
 
         underwaterobject.GetComponent<UnderWaterPostProcessing>().lensDistortion=lensDistortion;
         
          underwaterindensity = Mathf.Clamp(underwaterindensity, -50, 50);
          lensintensityx = Mathf.Clamp(underwaterindensity, 0,1 );
          lensintensityy = Mathf.Clamp(underwaterindensity, 0, 1);
          lenscenterx = Mathf.Clamp(underwaterindensity, 0, 1);
          lenscentery = Mathf.Clamp(underwaterindensity, 0, 1);*/
         

     }

    private void Update()
    {
        if (sualti.inwater)
        {
            UnderWaterEffect();
        }
    }

    private void UnderWaterEffect()
    {
        _t += 0.1f * Time.deltaTime;
        // lensdis.centerY.value = Mathf.Lerp(minimum, maximum, t);
        //lensdis.centerX.value = Mathf.Lerp(minimum, maximum, t);
        if (lensDis != null)
        {
            lensDis.centerY.value = Mathf.Lerp(minimum, maximum, _t);
            lensDis.centerX.value = Mathf.Lerp(minimum, maximum, _t);
        }


        if (_t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            _t = 0.0f;
        }

        //lensdis.intensity.value = Mathf.Lerp(-10f, 10f, lensdis.intensity.value * Time.deltaTime);
    }
}