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
        Destroy(gameObject, lifetime); // Autodestrucción en el tiempo que hemos puesto 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy!");
            ScoreManager.Instance.AddScore(127); // Añadir puntos al impacto
            Destroy(other.gameObject); // o llama a un método de vida del enemigo
            Destroy(gameObject);
        }
    }
}