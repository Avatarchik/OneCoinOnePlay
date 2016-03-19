using UnityEngine;
using System.Collections;

public class AdvancedTypeController : MonoBehaviour {

    [SerializeField]
    private MonsterMissileBase misNorth;
    [SerializeField]
    private MonsterMissileBase misSouth;
    [SerializeField]
    private MonsterMissileBase misWest;
    [SerializeField]
    private MonsterMissileBase misEast;

    private IEnumerator missileProcessRoutine;

    private Vector3 playerPos;
    
    public void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        missileProcessRoutine = MissileProcess();
        StartCoroutine(missileProcessRoutine);
    }

    public void StopProcess()
    {
        missileProcessRoutine = MissileProcess();
        StopCoroutine(missileProcessRoutine);
    }

    private IEnumerator MissileProcess()
    {
        misNorth.StartMissile(playerPos);
        misSouth.StartMissile(playerPos);
        misWest.StartMissile(playerPos);
        misEast.StartMissile(playerPos);
        yield return null;
    }
	
}
