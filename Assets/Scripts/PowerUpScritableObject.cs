using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/PowerUps Data")]
public class PowerUpScritableObject : ScriptableObject
{
    [SerializeField] private string powerUpType; // Speed,health,damage,etc
    [SerializeField] private float powerUpValue; // increase amount
    [SerializeField] private float timeLimit; // how long the power up lasts

    public string PowerUpType { get => powerUpType; set => powerUpType = value; }
    public float PowerUpValue { get => powerUpValue; set => powerUpValue = value; }
    public float TimeLimit { get => timeLimit; set => timeLimit = value; }
}
