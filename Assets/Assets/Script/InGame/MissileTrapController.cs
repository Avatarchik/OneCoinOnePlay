using UnityEngine;
using System.Collections;

public class MissileTrapController : MonoBehaviour {

    [SerializeField]
    private Transform originPos;
    [SerializeField]
    private GameObject[] missileObjects;
    private int missileNum;

    [SerializeField]
    private PlayerStatus playerStatus;

    private IEnumerator trapCoroutine;

    private float _genTime;
    public float genTime
    {
        set { _genTime = value; }
    }

    public void Init()
    {
        _genTime = 1.0f;
        missileNum = missileObjects.Length;
        for (int idx = 0; idx < missileNum; idx++)
        {
            EffectSettings settings = missileObjects[idx].GetComponent<EffectSettings>();
            settings.EffectDeactivated += (object sender, System.EventArgs e) =>
            {
                EffectEventArgsData arg = e as EffectEventArgsData;
                int MissileIdx = int.Parse(arg.objName);
                missileObjects[MissileIdx].transform.position = originPos.position;
            };

            settings.CollisionEnter += (object sender, CollisionInfo info) =>
            {
                if((info.Hit.transform.CompareTag("Player")) &&
                   (playerStatus.isDead == false))
                {
                    playerStatus.isDead = true;
                }
            };
        }

        trapCoroutine = MissileTrapProcess();
    }

    public void StartMissileTrap()
    {
        StartCoroutine(trapCoroutine);
    }

    public void StopMissileTrap()
    {
        StopCoroutine(trapCoroutine);
    }

    private IEnumerator MissileTrapProcess()
    {
        while(true)
        {
            for (int idx = 0; idx < missileNum; ++idx)
            {
                if(missileObjects[idx].activeSelf == false)
                    missileObjects[idx].SetActive(true);
                yield return new WaitForSeconds(_genTime);
            }
        }
    }
}
