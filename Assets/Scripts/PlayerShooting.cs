using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
     private float fireRate = 0.25f; // segundos entre disparos
    [SerializeField] private ParticleSystem shootingEffect; // Efecto de disparo    

    private float nextFireTime;

    private void Awake()
    {
        fireRate = Mathf.Abs(PlayerPrefs.GetFloat("FireRate", 0f)- 1f); 
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            shootingEffect.Play(); 
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}