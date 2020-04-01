using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class BloomProcesing : MonoBehaviour
{
    public PostProcessVolume volume;

    public float MaxBloom;
    public float MinBloom;
    public float MultiplierBloom;
    private bool goToMin = true;
    private bool goToMax = false;
    public float actualBloom;

    private Bloom bloom;

    void Start()
    {
        volume.profile.TryGetSettings(out bloom);
        actualBloom = MinBloom;

    }
    void Update()
    {
        UpOrDownBloom();
        OutBloom();
    }
    void UpOrDownBloom()
    {
        if (actualBloom <= MaxBloom && !goToMax)
        {
            actualBloom = actualBloom + MultiplierBloom * Time.deltaTime;
        }
        else
        {
            goToMin = false;
            goToMax = true;
        }
        if (actualBloom >= MinBloom && !goToMin)
        {
            actualBloom = actualBloom - MultiplierBloom * Time.deltaTime;
        }
        else
        {
            goToMin = true;
            goToMax = false;
        }
    }
    void OutBloom()
    {
        bloom.intensity.value = actualBloom;
    }
}
