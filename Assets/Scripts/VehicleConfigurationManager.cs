using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VehicleConfigurationManager : MonoBehaviour
{
    [SerializeField] private Scrollbar speedScrollbar;
    [SerializeField] private Scrollbar shootVelocity;
    [SerializeField] private Scrollbar torque;
    [SerializeField] private Scrollbar boostSpeed;
    [SerializeField] private int totalPoints;

    private void Awake()
    {
        totalPoints = PlayerPrefs.GetInt("Score", 0);
        speedScrollbar.size = PlayerPrefs.GetFloat("Speed", 0f);
        shootVelocity.size = PlayerPrefs.GetFloat("ShootVelocity", 0f);
        torque.size = PlayerPrefs.GetFloat("Torque", 0f);
        boostSpeed.size = PlayerPrefs.GetFloat("BoostSpeed", 0f);
    }


    public void Start()
    {
        speedScrollbar.size = PlayerPrefs.GetFloat("Speed", 0f);
        shootVelocity.size = PlayerPrefs.GetFloat("ShootVelocity", 0f);
        torque.size = PlayerPrefs.GetFloat("Torque", 0f);
        boostSpeed.size = PlayerPrefs.GetFloat("BoostSpeed", 0f);
    }

    private bool CheckPoints()
    { 
        return totalPoints >= 1000;
    }

    private void RestPoints()
    {
        totalPoints -= 1000;
        PlayerPrefs.SetInt("Score", totalPoints);
        PlayerPrefs.Save();
        ScoreManager.Instance.ResetScore();
    }


    public void AddSpeed()
    {
        if(speedScrollbar.size < 1f && CheckPoints())
        {
            speedScrollbar.size += 0.1f;
            RestPoints();
        }
    }
    public void RestSpeed()
    {
        if(speedScrollbar.size > 0f)
        {
            speedScrollbar.size -= 0.1f;
        }
    }

    public void AddShootVelocity()
    {
        if(shootVelocity.size < 1f && CheckPoints())
        {
            shootVelocity.size += 0.1f;
            RestPoints();
        }
    }

    public void RestShootVelocity()
    {
        if(shootVelocity.size > 0f)
        {
            shootVelocity.size -= 0.1f;
        }
    }

    public void AddTorque()
    {
        if(torque.size < 1f && CheckPoints())
        {
            torque.size += 0.1f;
            RestPoints();
        }
    }

    public void RestTorque()
    {
        if(torque.size > 0f)
        {
            torque.size -= 0.1f;
        }
    }

    public void AddBoostSpeed()
    {
        if(boostSpeed.size < 1f && CheckPoints())
        {
            boostSpeed.size += 0.1f;
            RestPoints();
        }   
    }

    public void RestBoostSpeed()
    {
        if(boostSpeed.size > 0f)
        {
            boostSpeed.size -= 0.1f;
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Speed", speedScrollbar.size);
        PlayerPrefs.SetFloat("ShootVelocity", shootVelocity.size);
        PlayerPrefs.SetFloat("Torque", torque.size);
        PlayerPrefs.SetFloat("BoostSpeed", boostSpeed.size);
        PlayerPrefs.Save();
        SceneManager.LoadScene("SelectLevel");
    }

}
