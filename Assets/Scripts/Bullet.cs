using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifetime = 3f;
    

    private void Start()
    {
        // La bala se mueve hacia su "derecha" local
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
        Destroy(gameObject, lifetime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy!");
            ScoreManager.Instance.AddScore(100); // Añadir puntos al impacto
            Destroy(other.gameObject); 
            Destroy(gameObject);
        }
    }
}