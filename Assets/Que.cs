using Unity.Mathematics;
using UnityEngine;

public class Que : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle , Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation , Time.deltaTime * speed); 
    }
}
