using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrap : MonoBehaviour
{
    public Transform trap;
    bool canFire = true;
    // float delay = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canFire) StartCoroutine(TrapFire());
    }

    /*void TrapFire()
    {
        delay += Time.deltaTime;
        if (delay >= 2f)
        {
            Instantiate(bullet,transform.position,transform.rotation);
            
        }
        if(delay>=4f)
        {
            Destroy(gameObject);
            delay = 0f;
        }
    }*/
    IEnumerator TrapFire()
    {
        Instantiate(trap, transform.position, transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(2.5f);
        canFire = true;
    }
}
