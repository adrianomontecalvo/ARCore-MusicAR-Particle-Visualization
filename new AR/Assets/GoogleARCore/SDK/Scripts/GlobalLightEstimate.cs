using UnityEngine;
using GoogleARCore;

public class GlobalLightEstimate : MonoBehaviour
{

    public static float value = 1f;

    void Update()
    {
        if (Frame.LightEstimate.State != LightEstimateState.Valid)
        {
            return;
        }

        const float LinearRampThreshold = 0.8f;
        const float MiddleGray = 0.18f;
        const float Inclination = 0.4f;

        float normalizedIntensity = Frame.LightEstimate.PixelIntensity / MiddleGray;
        float colorScale = 1.0f;

        if (normalizedIntensity < 1.0f)
        {
            colorScale = normalizedIntensity * LinearRampThreshold;
        }
        else
        {
            float b = LinearRampThreshold / Inclination - 1.0f;
            float a = (b + 1.0f) / b * LinearRampThreshold;
            colorScale = a * (1.0f - (1.0f / (b * normalizedIntensity + 1.0f)));
        }
        value = colorScale;
    }
}