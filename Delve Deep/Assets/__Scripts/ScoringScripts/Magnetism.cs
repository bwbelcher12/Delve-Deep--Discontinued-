using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    private bool active;
    private Vector3 targetPosition;
    private GameObject player;

    [SerializeField] float magnetStrenght;

    // Update is called once per frame
    void Update()
    {
        if (active)
            Magnetize();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {
            active = true;
            player = other.gameObject;
        }
    }

    void Magnetize()
    {
        Debug.Log("hi2");    
        
        float step = magnetStrenght * Time.deltaTime;

        magnetStrenght += 10 * Time.deltaTime;

        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + .35f, player.transform.position.z);
        this.transform.parent.transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
