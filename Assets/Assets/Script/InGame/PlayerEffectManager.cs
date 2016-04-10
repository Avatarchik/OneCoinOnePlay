using UnityEngine;
using System.Collections;

public class PlayerEffectManager : MonoBehaviour {

    [SerializeField]
    private GameObject prefabDeadEffect;
    [SerializeField]
    private GameObject prefabReviveEffect;
    [SerializeField]
    private Transform playerTrans;

    public void DeadEffectOn()
    {
        Vector3 pos = playerTrans.position;
        pos.y += 1.5f;
        Instantiate(prefabDeadEffect, pos, new Quaternion(0, 0, 0, 0));
    }

    public void ReviveEffectOn()
    {
        Vector3 pos = playerTrans.position;
        pos.y += 1.5f;
        GameObject obj = Instantiate(prefabReviveEffect,
            pos, new Quaternion(0, 0, 0, 0)) as GameObject;
        obj.transform.parent = playerTrans;
    }
}
