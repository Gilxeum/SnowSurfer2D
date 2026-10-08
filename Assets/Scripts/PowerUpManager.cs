using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpScritableObject powerUpData;

    PlayerController playerController;
    SpriteRenderer powerUpSpriteRenderer;

    float timeLeft;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        powerUpSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        timeLeft = powerUpData.TimeLimit;
    }

    private void Update()
    {
        CountDownPowerUpTime();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && powerUpSpriteRenderer.enabled) 
        {
            powerUpSpriteRenderer.enabled = false;
            playerController.ApplyPowerUp(powerUpData);
        }
    }

    private void CountDownPowerUpTime()
    {
        if(powerUpSpriteRenderer == false)
        {
            if(timeLeft >0)
            {
                timeLeft -= Time.deltaTime;

                if(timeLeft<=0)
                {
                    playerController.DeactivatePowerUp(powerUpData);
                }
            }
        }
    }
}
