using UnityEngine;
using System.Collections;

public class PlayerAttackManager : MonoBehaviour {

    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform shotStartPos;
    private RaycastHit hitPoint;
    [SerializeField]
    private PlayerStatus playerStatus;

    private GameObject[] playerShots = new GameObject[20];
    private int maxShots = 20;
    private int curShotIdx = 0;
    
    void Start()
    {
        for(int idx = 0; idx < maxShots; idx++)
        {
            GameObject shotPrefab = playerStatus.GetPlayerShot();
            playerShots[idx] = Instantiate(shotPrefab,
                                shotStartPos.transform.position,
                                new Quaternion(0, 0, 0, 0)) as GameObject;
            playerShots[idx].GetComponent<BaseShotProcess>().Init();
        }
    }

    public void AttackInit()
    {
        playerAnimator.SetTrigger("Attack1Trigger");
    }

    private void AttackStart()
    {
        if (curShotIdx >= maxShots) curShotIdx = 0;
        if (playerShots[curShotIdx].activeSelf == true)
        {
            curShotIdx++;
            return;
        }
        playerShots[curShotIdx].SetActive(true);
        playerShots[curShotIdx].transform.position = shotStartPos.transform.position;
        playerShots[curShotIdx].GetComponent<BaseShotProcess>().StartShotProcess();
        curShotIdx++;
    }
    
}
