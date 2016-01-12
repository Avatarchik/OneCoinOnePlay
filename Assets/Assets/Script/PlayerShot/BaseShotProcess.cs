﻿using UnityEngine;
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
    

	void Start ()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        dirVec = playerPos.forward;

        shotMoveRoutine = ShotMoving();
        StartCoroutine(shotMoveRoutine);
    }

    IEnumerator ShotMoving()
    {
        while(true)
        {
            gameObject.transform.position += dirVec * Time.deltaTime * 5.0f;
            yield return new WaitForSeconds(0.03f);
        }
        
    }
    
    public void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Shot Hit");
        
        StopCoroutine(shotMoveRoutine);
        shotParticle.Stop();
        afterEffect.SetActive(true);
        Destroy(gameObject, afterEffectPartice.duration);
    }
}