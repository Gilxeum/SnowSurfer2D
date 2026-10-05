using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [SerializeField] private float boostSpeed = 35f;
    [SerializeField] private ParticleSystem snowEffect;
    [SerializeField] private ParticleSystem boostEffect;
    [SerializeField] private ScoreManager scoreManager;

    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb;


   
    InputAction moveAction;
    Vector2 moveInput;

    
    float baseSpeed = 10f;
    float previousRotation;
    float totalRotation;
    int flipCount;


    private bool canControlPlayer = true;
    public bool CanControlPlayer { get => canControlPlayer; set => canControlPlayer = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canControlPlayer)
        {
            PlayerTorque();
            BoostPlayer();
            CalculateFlips();
            Debug.Log("Player can control the player");
        }
        else
        {
            surfaceEffector2D.speed = 1f;
        }
    }

    /// <summary>
    /// Calculates the number of flips the player has performed based on the player's rotation.
    /// </summary>
    private void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z; // Get the current rotation of the player in degrees
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation); // Calculate the change in rotation since the last frame

        if(Mathf.Abs(totalRotation) > 340) // If the total rotation exceeds or equals 360 degrees, the player has completed a flip
        {
            flipCount++; // Increment the flip count
            Debug.Log($"Player has completed {flipCount} flips!"); 
            scoreManager.AddScore(flipCount*100); // Update the score based on the number of flips
            totalRotation = 0; // Reset the total rotation for the next flip
        }
       
       previousRotation = currentRotation; // Update the previous rotation for the next frame
    }

    /// <summary>
    /// Applies torque to the player based on the horizontal input from the move action.
    /// </summary>
    void PlayerTorque()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        if (moveInput.x < 0)
        {
            rb.AddTorque(torqueAmount);
        }
        else if (moveInput.x > 0)
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        //Increase the player's speed when the up arrow key is pressed
        //Surface effecor speed is increased to boostSpeed
        if (moveInput.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed; // Boost speed
            if(!boostEffect.isPlaying)
            {
                boostEffect.Play(); // Play the boost effect
            }
            Debug.Log("Boosting!"); // Log message for debugging
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed; // Normal speed
            boostEffect.Stop(); // Stop the boost effect
            Debug.Log("Normal speed"); // Log message for debugging
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            snowEffect.Play(); // Play the snow effect when the player is on the floor
            Debug.Log("Player is on the floor");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            snowEffect.Stop(); // Stop the snow effect when the player leaves the floor
            Debug.Log("Player has left the floor");
        }
    }

}
