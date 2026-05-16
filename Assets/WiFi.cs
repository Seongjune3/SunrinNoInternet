using NUnit.Framework;
using UnityEngine;

public class WiFi : Que
{
    public NewMonoBehaviourScript playerMove;
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float maxDistance;

    [SerializeField]
    bool isShutDown = false;

    [SerializeField]
    bool startWifiError = false;




    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("SunrinWiFiStop" , 5f , 5f);  // (함수 이름 , 시작 시간 , 반복 시간)
    }


    void Update()
    {
        SunrinWiFi();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startWifiError = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            startWifiError = false;
        }
    }
    
    void SunrinWiFi()
    {
        if (isShutDown) return;
        
        float distance = (target.position - transform.position).magnitude;

        float bee = distance / maxDistance; //거리 비율 계산

        if (bee <= 0.4f)
        {
            spriteRenderer.sprite = sprites[3];
            playerMove.speed = 200f;

        }
        else if (bee <= 0.6f)
        {
            spriteRenderer.sprite = sprites[2];
            playerMove.speed = 150f;
        }
        else if (bee <= 0.8f)
        {
            spriteRenderer.sprite = sprites[1];
            playerMove.speed = 100f;
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
            playerMove.speed = 70f;
        }
    }

    void SunrinWiFiStop()
    {
        if (!startWifiError) return;
        
        int day = Random.Range(0 , 2);

        Debug.Log(day);

        if (day == 0)
        {
            isShutDown = true;
            playerMove.speed = 0f;
        }
        else
        {
            isShutDown = false;
        }
    }

}
