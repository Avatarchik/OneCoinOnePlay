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
    
    public void AttackInit()
    {
        playerAnimator.SetTrigger("Attack1Trigger");
    }

    private void AttackStart()
    {
        if (Physics.Raycast(shotStartPos.position,
           shotStartPos.forward, out hitPoint))
        {
            Debug.Log("startP : " + shotStartPos.position);
            Debug.Log("endP : " + hitPoint.point);
            Debug.DrawLine(shotStartPos.position, hitPoint.point,
                Color.blue,
                5.0f);
            GameObject shotPrefab = playerStatus.GetPlayerShot();
            Instantiate(shotPrefab, 
                shotStartPos.transform.position,
                new Quaternion(0, 0, 0, 0));
            
        }
    }
    
}
