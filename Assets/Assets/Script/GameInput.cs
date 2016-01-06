using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {

    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform shotStartPos;
    private RaycastHit hitPoint;

    [SerializeField]
    private PlayerStatus playerStatus;

    private bool isShotInterval = false;
  
    public void PressAttackBtn()
    {
        playerAnimator.SetTrigger("Attack1Trigger");
        if (isShotInterval == false) StartCoroutine(ShotIntervalTime());
    }

    IEnumerator ShotIntervalTime()
    {
        if (Physics.Raycast(shotStartPos.position,
            shotStartPos.forward, out hitPoint))
        {
            GameObject shotObject = Instantiate(playerStatus.GetPlayerShot(),
                shotStartPos.position,
                new Quaternion(0, 0, 0, 0)) as GameObject;
            EffectSettings shotSettings = shotObject.GetComponent<EffectSettings>();
            shotSettings.Target = hitPoint.transform;

        }
        isShotInterval = true;
        yield return new WaitForSeconds(1.02f);
        isShotInterval = false;
    }
}
