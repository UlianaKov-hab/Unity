using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 20f;
    public float leftAndRightEdge = 25f;
    public float channceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    private void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);            
    }

    // Update is called once per frame
    void Update()
    { 
        //������� �����������
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //��������� �����������
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //������ ��� ������
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//������ ��� ����
        }
        
        
    }
    private void FixedUpdate()
    {
        if(Random.value < channceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
