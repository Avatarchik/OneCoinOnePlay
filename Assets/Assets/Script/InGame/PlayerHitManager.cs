using UnityEngine;
using System.Collections;

public class PlayerHitManager : MonoBehaviour {

    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField]
    private GameObject prefabDeadEffect;
    private bool _isTriggerOff = false;
    public bool isTriggerOff
    {
        set { _isTriggerOff = value; }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Monster") && 
            (_isTriggerOff == false))
        {
            _isTriggerOff = true;
            playerStatus.isDead = true;

            Vector3 effectPos = gameObject.transform.position;
            effectPos.y += 1.5f;
            Instantiate(prefabDeadEffect,
                effectPos, new Quaternion(0, 0, 0, 0));
            DeadProcess();
        }
    }

    private void DeadProcess()
    {
        gameObject.SetActive(false);
    }

    public void ReviveProcess()
    {
        // to do
    }
    
}
