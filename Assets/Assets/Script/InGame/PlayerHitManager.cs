using UnityEngine;
using System.Collections;

public class PlayerHitManager : MonoBehaviour {

    [SerializeField]
    private PlayerStatus playerStatus;
    
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            playerStatus.isDead = true;
        }
    }
    
    
}
