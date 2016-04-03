using UnityEngine;
using System.Collections;

public class PlayerHitManager : MonoBehaviour {

    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField]
    private GameObject playerDeadEffect;
    private bool isPlayerDead = false;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Monster") && 
            (isPlayerDead == false))
        {
            isPlayerDead = true;
            playerStatus._isDead = true;
            playerDeadEffect.SetActive(true);
        }
    }

    //private IEnumerator DeadProccessing()
    //{
    //    Vector3 pos = gameObject.transform.position;
    //    float sec = 2.0f;
    //    while (sec > 0.0f)
    //    {
    //        pos.y -= 0.05f;
    //        gameObject.transform.position = pos;
    //        yield return new WaitForSeconds(0.01f);
    //        sec -= 0.01f;
    //    }
    //}
}
