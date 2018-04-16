using UnityEngine;

[ExecuteInEditMode]
public class EnvironmentalLightController : MonoBehaviour
{

    public Light environmentLight;
    public float intensity = 1f;

    void Start()
    {
        // set default intensity
        environmentLight.intensity = intensity;
    }

    public void Update()
    {
        environmentLight.intensity = GlobalLightEstimate.value * intensity;
    }
}