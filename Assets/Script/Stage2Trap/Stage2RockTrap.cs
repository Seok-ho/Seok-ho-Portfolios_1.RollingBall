using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2RockTrap : MonoBehaviour
{
    float speed = 15f;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>(); // 소리 가져옴 
        sound.Play();   //돌이 생성되면 바로 실행시킴   
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        float shoot = speed * Time.deltaTime;
        transform.Translate(Vector3.right * shoot);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
