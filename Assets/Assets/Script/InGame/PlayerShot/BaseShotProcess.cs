using UnityEngine;
using System.Collections;

public class BaseShotProcess : MonoBehaviour {

    private Vector3 dirVec;
    private Transform playerPos;
    [SerializeField]
    private GameObject afterEffect;
    [SerializeField]
    private ParticleSystem afterEffectPartice;
    [SerializeField]
    private ParticleSystem shotParticle;
    private IEnumerator shotMoveRoutine;
    

	public void Init()
    {
        playerPos = GameObject.Find("Player").transform;
        shotMoveRoutine = ShotMoving();
        gameObject.SetActive(false);
        afterEffect.SetActive(false);
    }

    public void StartShotProcess()
    {
        dirVec = playerPos.forward;
        StartCoroutine(shotMoveRoutine);
    }

    IEnumerator ShotMoving()
    {
        while(true)
        {
            gameObject.transform.position += dirVec * Time.deltaTime * 5.0f;
            yield return null;
        }
        
    }
    IEnumerator DeActive()
    {
        yield return new WaitForSeconds(afterEffectPartice.duration);
        afterEffect.SetActive(false);
        gameObject.SetActive(false);
    }
    
    public void OnTriggerEnter(Collider coll)
    {
        if(coll.tag.Equals("Monster") ||
          (coll.tag.Equals("Wall")))
        {
            StopCoroutine(shotMoveRoutine);
            shotParticle.Stop();
            afterEffect.SetActive(true);
            StartCoroutine(DeActive());
        }
        
    }
}
