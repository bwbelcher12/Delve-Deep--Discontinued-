using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxUpdate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject.Find("Attack").GetComponent<Attack>().enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject.Find("Attack").GetComponent<Attack>().enemies.Remove(other.gameObject);
        }
    }
}
