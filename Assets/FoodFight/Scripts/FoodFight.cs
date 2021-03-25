using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodFight : MonoBehaviour
{
    public Target targetPrefab;
    public BoxCollider spawnArea;
    public float gameDuration;
    public TMP_Text scoreText;
    public TMP_Text countdownText;

    public int score;
    public float countdown;

    private void Start()
    {
        // Spawn the first target
        SpawnTarget();

        // Reset the countdown
        countdown = gameDuration;

        // Update the UI
        UpdateUI();
    }

    private void Update()
    {
        // Decrease the game countdown
        countdown -= Time.deltaTime;

        // If the countdown has run out 
        if(countdown <= 0f)
        {
            // Game over
            GameOver();
        }

        // Update the UI
        UpdateUI();
    }

    private void GameOver()
    {
        // Pause the time
        Time.timeScale = 0f;
    }

    private void UpdateUI()
    {
        // Update the score text
        scoreText.text = $"Score: {score}";

        // Update the countdown text
        countdownText.text = $"Time Left: {countdown:F1} sec";
    }

    public void OnTargetHit()
    {
        // Increase the score
        score += 1;

        // Spawn a new target
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        // Calculate a new random position for the target
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));

        // Spawn the new target
        Target newTarget = Instantiate(targetPrefab, randomPosition, Quaternion.Euler(-90, 0, 0));
        
        // Let the target know about the game script
        newTarget.game = this;
    }
}
