using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    private Animator monsterAnimator;
    private MonsterGenerator monGenerator;
    private CapsuleCollider capColl;

    private string[] deathAni = new string[3];
    void Start ()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        monsterAnimator = gameObject.GetComponent<Animator>();
        monGenerator = GameObject.FindGameObjectWithTag("MonGenerator").GetComponent<MonsterGenerator>();
        capColl = gameObject.GetComponent<CapsuleCollider>();

        deathAni[0] = "death01";
        deathAni[1] = "death02";
        deathAni[2] = "death03";

        StartCoroutine(MovingProcess());
	}

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeadProcess());
        }
    }
    IEnumerator DeadProcess()
    {
        monGenerator.SubMonsterNum();
        monsterAnimator.Play(deathAni[Random.Range(0,3)]);
        StopCoroutine(MovingProcess());
        navMeshAgent.enabled = false;
        capColl.enabled = false;

        Vector3 pos = gameObject.transform.position;
        float sec = 2.5f;
        while(sec > 0.0f)
        {
            pos.y -= 0.05f;
            gameObject.transform.position = pos;
            yield return new WaitForSeconds(0.05f);
            sec -= 0.05f;
        }
        DestroyImmediate(gameObject);
    }
    IEnumerator MovingProcess()
    {
        while(true)
        {
            if(navMeshAgent.enabled == true)
                navMeshAgent.destination = playerTransform.position;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    
	
}
