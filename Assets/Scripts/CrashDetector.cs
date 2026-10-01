using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
       int layerIndex = LayerMask.NameToLayer("Floor");
       
       if(other.gameObject.layer == layerIndex)
       {
           Debug.Log("Player has crashed!");
           Invoke(nameof(ReloadScene), 2f); // Reload the scene after 2 seconds
       }
   }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
