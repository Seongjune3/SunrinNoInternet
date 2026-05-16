using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    Vector2 player;
    Vector2 a = new Vector2(1,2);
    Vector2 b = new Vector2(2,3);
    
    void Start()
    {
        Debug.Log(Vector2.Lerp(a , b , 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        player.x = Input.GetAxisRaw("Horizontal");
        player.y = Input.GetAxisRaw("Vertical");

        
    }

    void FixedUpdate()
    {
        rb.AddForce(player.normalized * speed * Time.deltaTime);
    }
}
