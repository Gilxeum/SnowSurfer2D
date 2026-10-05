using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [SerializeField] private float boostSpeed = 35f;
    [SerializeField] private ParticleSystem snowEffect;
    [SerializeField] private ParticleSystem boostEffect;

    

    float baseSpeed = 10f;

    SurfaceEffector2D surfaceEffector2D;



    InputAction moveAction;
    Vector2 moveInput;
    Rigidbody2D rb;

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
            Debug.Log("Player can control the player");
        }
        else
        {
            surfaceEffector2D.speed = 1f;
        }
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
