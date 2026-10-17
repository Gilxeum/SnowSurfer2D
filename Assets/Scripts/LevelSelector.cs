using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        //Getayout group 
        Transform levels = transform.GetChild(0);
        Debug.Log("Unlocked level: " + unlockedLevel);
        for (int i = 0; i < levels.childCount; i++)
        {
            Transform level = levels.GetChild(i);
            Button button = level.GetComponent<Button>();
            button.interactable =  unlockedLevel >= i + 1;
        }   
        //Prueba
    }
}
