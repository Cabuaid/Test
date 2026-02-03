using UnityEngine;

public class Hurtplayer : MonoBehaviour
{
    private float hurtTimer = 0f;
    private bool isTouching = false;
    private healtmanager healthmanager;
    public int damageToGive = 10;
    public float damageInterval = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthmanager = FindFirstObjectByType<healtmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0f)
            {
                healthmanager.HurtPlayer(damageToGive);
                hurtTimer = damageInterval;
            }

        }
    
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = true;
            hurtTimer = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = true;
        }
    
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouching = false;
            hurtTimer = 0f;
        }
    }
}
