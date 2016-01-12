using UnityEngine;
using System.Collections;

public class GameUIManager : MonoBehaviour {

    [SerializeField]
    private PlayerAttackManager playerAtkMgr;

    public void ClickAttackBtn()
    {
        playerAtkMgr.AttackInit();
    }
}
