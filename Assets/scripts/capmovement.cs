using UnityEngine;

public class capmovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    KeyCode up = KeyCode.W;
    KeyCode left = KeyCode.D;
    KeyCode right = KeyCode.A;
    KeyCode down = KeyCode.S;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up)) // to be able to go upp 
        {
            print("go upp");
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;


        }

        if (Input.GetKey(left)) // to be able to go rigth
        {
            print("go left");
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;


        }


        if (Input.GetKey(right)) // to be able to go left
        {
            print("go right");
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;


        }

        if (Input.GetKey(down)) // to be able to go down 
        {
            print("go dow");
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;


        }
   
    
    
    
    }

   
     

}
