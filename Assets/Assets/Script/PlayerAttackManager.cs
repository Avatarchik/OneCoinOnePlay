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
        for(int idx = 0; idx < 20; idx++)
        {
            GameObject shotPrefab = playerStatus.GetPlayerShot();
            playerShots[idx] = Instantiate(shotPrefab,
                                shotStartPos.transform.position,
                                new Quaternion(0, 0, 0, 0)) as GameObject;
            playerShots[idx].SetActive(false);
        }
    }

    public void AttackInit()
    {
        playerAnimator.SetTrigger("Attack1Trigger");
    }

    private void AttackStart()
    {
        if (curShotIdx > 20) curShotIdx = 0;
        playerShots[curShotIdx].SetActive(true);
        playerShots[curShotIdx].transform.position = shotStartPos.transform.position;
        curShotIdx++;
    }
    
}
