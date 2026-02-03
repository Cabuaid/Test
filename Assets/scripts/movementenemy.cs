using UnityEngine;

public class movementenemy : MonoBehaviour
{
    Vector3 dir;
    [SerializeField] float speed = 4;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<capmovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = (player.position - transform.position).normalized; //-1 - 1
        transform.position += dir * speed * Time.deltaTime;
    }
}
