using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {     
        float amount = speed * Time.deltaTime; //총알 움직이는 정도
        transform.Translate(Vector3.forward * amount); //총알 나가는 속도 
    }
   
}
