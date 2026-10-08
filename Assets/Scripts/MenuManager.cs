using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Level1");
    }

    public void CharacterSelection()
    {
        // Load the character selection scene
        SceneManager.LoadScene("CharacterScene");
    }
   public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturnMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Menu");
    } 
    
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    /// <summary>
    /// Store the selected character index in playerPrefs
    /// </summary>
    /// <param name="characterIndex"></param>
    public void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();
        ReturnMenu();

    }
}
    