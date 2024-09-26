using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing;
    public Transform player;
    Transform currentDest;
    Vector3 dest;
    int randNum;
    public int destinationAmount;
    public Vector3 rayCastOffset;
    public string deathScene;

    public SoundManager1 soundmanager;

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
        
        if (chasing == true)
        {
            if(!soundmanager.alreadychase)
                soundmanager.PlayChaseSound();
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("ghost_run");
            aiAnim.ResetTrigger("ghost_idle");
            aiAnim.SetTrigger("ghost_run");
            float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                player.gameObject.SetActive(false);
                aiAnim.ResetTrigger("ghost_run");
                aiAnim.ResetTrigger("ghost_idle");
                aiAnim.SetTrigger("ghost_attack");
                StartCoroutine(deathRoutine());
                chasing = false;
            }
        }
        if (walking == true)
        {
            if(soundmanager.alreadychase)
                soundmanager.PlayBackSound();
            
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("ghost_idle");
            aiAnim.SetTrigger("ghost_run");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("ghost_run");
                aiAnim.SetTrigger("ghost_idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }
    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}
