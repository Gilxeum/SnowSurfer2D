using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathEffect;

    PlayerController playerController;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

   void OnTriggerEnter2D(Collider2D other)
   {
       int layerIndex = LayerMask.NameToLayer("Floor");
       
       if(other.gameObject.layer == layerIndex)
        {
            playerController.CanControlPlayer = false; // Disable player control
            Debug.Log("Player has crashed!");

            deathEffect.Play(); // Play the death effect
            Invoke(nameof(ReloadScene), 2f); // Reload the scene after 2 seconds
        }
   }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
