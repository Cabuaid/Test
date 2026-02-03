using Unity.VisualScripting;
using UnityEngine;

public class musketer : MonoBehaviour
{
    Vector3 dir;
    [SerializeField] float speed = 4;
    Transform player;
    [SerializeField] float attackRange = 3;
    public float shootpoint;
    public float cooldown = 1.5f;
    float timer = 0;
    public GameObject Enemybullet;
    public float bulletForce = 10f;
    [SerializeField] float distanceFromEnemy = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<capmovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = (player.position - transform.position).normalized; //-1 - 1

        if (Vector2.Distance(player.position, transform.position) > attackRange)
        {
            transform.position += dir * speed * Time.deltaTime;

            
        }
        else if (Vector2.Distance(player.position, transform.position) < attackRange-1)
        {

            transform.position += -dir * speed * Time.deltaTime;
        }
        if (timer >= cooldown && Vector2.Distance(player.position, transform.position) < attackRange)//active the shoot
        {
            print("shoot");
            Shoot();
            timer = 0;
        }
        timer += Time.deltaTime;

    }
   private void Shoot()
    {
        //always look and shoot the player
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 pos = transform.position + direction * distanceFromEnemy;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle - 90);

        //make the shoot workt
        print("kaboom");
        GameObject bullet = Instantiate(Enemybullet, pos, rot);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
