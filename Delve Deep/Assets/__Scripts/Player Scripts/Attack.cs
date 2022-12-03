using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject attackEffect;
    [SerializeField] GameObject attackHitbox;

    [SerializeField] AudioClip swingSound;
    private AudioManager am;

    private GameManager gm;

    [SerializeField] int damagePoints;
    [SerializeField] int attackSpeed;
    public List<GameObject> enemies = new List<GameObject>();

    bool _canAttack;

    private void Awake()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _canAttack = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gm.gameOver || gm.isPaused)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            AttackAction();
        }
    }

    private void AttackAction()
    {

        if(_canAttack)
        {
            am.PlayAudio(swingSound, .3f);
            StartCoroutine(Slash());

            foreach (GameObject g in enemies.ToArray())
            {
                g.GetComponent<EnemyHealth>().Hit(damagePoints);
            }
        }
    }

    IEnumerator Slash()
    {
        _canAttack = false;

        GameObject aE = Instantiate(attackEffect, new(transform.position.x, transform.position.y + .5f, transform.position.z), transform.rotation);

        aE.transform.eulerAngles = new(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 50f, transform.rotation.eulerAngles.z);

        float degreesMoved = 0;

        while (degreesMoved < 100)
        {
            aE.transform.localEulerAngles = new(aE.transform.rotation.eulerAngles.x, aE.transform.rotation.eulerAngles.y - (attackSpeed * Time.deltaTime), aE.transform.rotation.eulerAngles.z);

            degreesMoved += attackSpeed * Time.deltaTime;

            yield return null;
        }
        

        float waitTime = 0f;

        while (waitTime < .07)
        {
            waitTime += Time.deltaTime;
            yield return null;
        }

        Destroy(aE);

        _canAttack = true;
        yield return null;
    }

}
