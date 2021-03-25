using DigitalRuby.RainMaker;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public bool raining;
    public TMP_Text forecastText;
    public RainScript rainEffect;
    public List<Animator> treeAnimators = new List<Animator>();

    public void ToggleRain()
    {
        // Toggle the rain
        raining = !raining;

        // Update the forecast text
        forecastText.text = raining ? "Forecast:\nRaining" : "Forecast:\nCalm";

        // Enable or disable the rain effect
        rainEffect.RainIntensity = raining ? 1f : 0f;

        // For each tree animator in the forest
        foreach(Animator treeAnimator in treeAnimators)
        {
            // Enable or disable the animator depending on the weather
            treeAnimator.enabled = raining;
        }
    }
}
