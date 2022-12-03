using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private int hitPoints;

    [SerializeField] ParticleSystem killEffect;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;

    private bool hitable;
    private AudioManager am;
    private GameManager gm;

    private void Awake()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        hitable = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hitable)
        {
            Hit(1);

            CheckIfDead();

            StartCoroutine(Invulnerable());
        }
    }

    public void Hit(int damage)
    {
        am.PlayAudio(hitSound, .7f);
        ParticleSystem he = Instantiate(hitEffect, transform.position, killEffect.transform.rotation);
        he.transform.parent = transform;

        hitPoints -= damage;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (hitPoints <= 0)
        {
            am.PlayAudio(deathSound, .3f);
            Kill();
        }

    }

    private void Kill()
    {
        Destroy(gameObject);
        Instantiate(killEffect, transform.position + Vector3.forward, killEffect.transform.rotation);
        gm.GameOver(); 
    }

    IEnumerator Invulnerable()
    {
        hitable = false;

        float time = 1f;

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        hitable = true;
        yield return null;
    }
}
