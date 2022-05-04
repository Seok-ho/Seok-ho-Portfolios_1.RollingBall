using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    float speed = 15f; //트랩이 날라가는 속도 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4); //4초 후 스스로 파괴함 
    }

    // Update is called once per frame
    void Update()
    {
        float amount = speed * Time.deltaTime; //총알 움직이는 정도
        transform.Translate(Vector3.right * amount); //총알 나가는 속도 
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
