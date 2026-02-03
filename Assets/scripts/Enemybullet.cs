using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public int damage = 20;
    public float lifetime = 1f;
    healtmanager playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
        playerHealth = FindAnyObjectByType<healtmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        healtmanager Player = other.GetComponent<healtmanager>();
        if (Player != null)
        {
            playerHealth.HurtPlayer(damage);
        }
        
        
    }
}
