using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDrop : MonoBehaviour
{
    public int points = 0;

    private bool goingUp;

    public Vector3 landingPos;

    [SerializeField] AudioClip pickupSound;
    private AudioManager am;


    private void Awake()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        goingUp = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.CompareTag("Player"))
        {
            am.PlayAudio(pickupSound, .5f);
            other.collider.transform.parent.transform.Find("PlayerUICanvas").GetComponent<CharacterUIFollower>().CollectPoints(points);
            Destroy(gameObject);
        }

        if(other.collider.transform.CompareTag("Ground"))
        {
            //PauseMovement();
        }

    }

    void PauseMovement()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Destroy(rb);

        landingPos = transform.position;

        //StartCoroutine(UpAndDown());
    }

    IEnumerator UpAndDown()
    {
        while (true)
        {

            if (transform.position.y < landingPos.y + .3f && goingUp)
            {
                transform.position += (Vector3.up * .3f * Time.deltaTime);

                if(transform.position.y >= landingPos.y + .3f)
                {
                    goingUp = false;
                }

                yield return null;
            } else if (transform.position.y > landingPos.y && !goingUp)
            {
                transform.position += (Vector3.down * .3f * Time.deltaTime);

                if(transform.position.y <= landingPos.y)
                {
                    goingUp = true;
                }

                yield return null;
            }
            
        }
    }
}
