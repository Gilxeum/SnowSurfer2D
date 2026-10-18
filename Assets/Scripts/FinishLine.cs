using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 2f;
    [SerializeField] private  List<ParticleSystem> finishEffects;
    [SerializeField] private int NextLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ScoreManager.Instance.SaveScore(); // Save the score when the player crosses the finish line
            Debug.Log("Player has crossed the finish line!");
            foreach (ParticleSystem particle in finishEffects)
                particle.Play();// Play the finish effect

            PlayerPrefs.SetInt("UnlockedLevel", NextLevel);
            PlayerPrefs.Save();
            Invoke(nameof(ReloadScene), reloadDelay); // Reload the scene after the specified delay
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level" + NextLevel);
    }
}
