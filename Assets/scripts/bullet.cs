using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 20;
    public float lifetime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealthManager enemy = other.GetComponent<EnemyHealthManager>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
