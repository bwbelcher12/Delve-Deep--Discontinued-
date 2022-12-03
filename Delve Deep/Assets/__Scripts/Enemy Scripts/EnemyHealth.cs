using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int hitPoints;

    [SerializeField] ParticleSystem killEffect;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] GameObject pointDrop;

    GameObject enemySpawner;


    private AudioManager am;

    private void Awake()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        enemySpawner = GameObject.Find("Enemy Spawner");
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
        if(hitPoints <= 0)
        {
            am.PlayAudio(deathSound, .3f);
            Kill();
        }

    }

    private void Kill()
    {
        enemySpawner.GetComponent<EnemySpawnController>().enemyCount--;
        enemySpawner.GetComponent<EnemySpawnController>().UpdateWaveCounter();

        GetComponent<EnemyMovementController>().colorer.isTarget = false;
        GameObject.Find("Attack").GetComponent<Attack>().enemies.Remove(gameObject);
        Destroy(gameObject);
        Instantiate(killEffect, transform.position + Vector3.forward, killEffect.transform.rotation);

        spawnPoints();
    }

    private void spawnPoints()
    {
        GameObject pd = Instantiate(pointDrop, transform.position, pointDrop.transform.rotation);
        Rigidbody rb = pd.GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-2, 2), 5, Random.Range(-2, 2), ForceMode.Impulse);

        pd.GetComponent<PointDrop>().points = Random.Range(15, 25);
    }
}
