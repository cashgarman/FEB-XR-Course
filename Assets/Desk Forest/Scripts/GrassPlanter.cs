using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GrassPlanter : MonoBehaviour
{
    public Transform placeholderGrass;
    public float plantingGrassDuration;
    public float timeBetweenGrassPlants;
    public Button plantGrassButton;
    public float plantingRadius;

    private bool planting;
    private float timeLeftPlantingGrass;
    private float timeLeftUntilNextGrassPlant;

    public void StartPlantingGrass()
    {
        // Mark as planting grass
        planting = true;

        // Reset the time left planting grass
        timeLeftPlantingGrass = plantingGrassDuration;

        // Disable the plant grass button
        plantGrassButton.interactable = false;
    }

    private void Update()
    {
        // If we're planting grass
        if(planting)
        {
            // Countdown the time left planting grass
            timeLeftPlantingGrass -= Time.deltaTime;

            // If we should stop planting grass
            if(timeLeftPlantingGrass <= 0f)
            {
                // Stop planting grass
                StopPlantingGlass();
            }

            // Countdown the time until we should plant the next grass
            timeLeftUntilNextGrassPlant -= Time.deltaTime;

            // If it is time to plant a new grass
            if(timeLeftUntilNextGrassPlant <= 0f)
            {
                // Plant a grass
                PlantGrass();

                // Reset the grass planting timer
                timeLeftUntilNextGrassPlant = timeBetweenGrassPlants;
            }
        }
    }

    private void StopPlantingGlass()
    {
        // Unmark as planting grass
        planting = false;

        // Enable the plant grass button
        plantGrassButton.interactable = true;
    }

    public void PlantGrass()
    {
        // Calculate a random position for the grass
        Vector3 randomOffset = Random.insideUnitSphere * plantingRadius;
        randomOffset.y = 0;

        // Make a clone of the placeholder grass
        Transform newTree = Instantiate(placeholderGrass, placeholderGrass.position + randomOffset, placeholderGrass.rotation);
        newTree.SetParent(null, true);
    }
}
