using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    private Animator monsterAnimator;
    private MonsterGenerator monGenerator;
    private CapsuleCollider capColl;
    private string[] deathAni = new string[3];
    private IEnumerator moveCoroutine;
  
    public void Init()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        monsterAnimator = gameObject.GetComponent<Animator>();
        monGenerator = GameObject.FindGameObjectWithTag("MonGenerator").GetComponent<MonsterGenerator>();
        capColl = gameObject.GetComponent<CapsuleCollider>();

        navMeshAgent.enabled = true;
        capColl.enabled = true;

        deathAni[0] = "death01";
        deathAni[1] = "death02";
        deathAni[2] = "death03";
        moveCoroutine = MovingProcess();
        StartCoroutine(moveCoroutine);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("PlayerShot"))
        {
            StartCoroutine(DeadProcess());
        }
    }
    

    IEnumerator DeadProcess()
    {
        monsterAnimator.Play(deathAni[Random.Range(0, 3)]);
        StopCoroutine(moveCoroutine);
        navMeshAgent.enabled = false;
        capColl.enabled = false;

        Vector3 pos = gameObject.transform.position;
        float sec = 2.5f;
        while (sec > 0.0f)
        {
            pos.y -= 0.05f;
            gameObject.transform.position = pos;
            yield return new WaitForSeconds(0.05f);
            sec -= 0.05f;
        }
        gameObject.SetActive(false);
    }
    IEnumerator MovingProcess()
    {
        while (true)
        {
            if (navMeshAgent.enabled == true)
                navMeshAgent.destination = playerTransform.position;
            yield return new WaitForSeconds(0.5f);
        }

    }
}
