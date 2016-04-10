using UnityEngine;
using System.Collections;

/// <summary>
///  플레이어 스킬 관리 매니저.
/// </summary>
public class PlayerSkillManager : MonoBehaviour {

    [SerializeField]
    private PlayerStatus playerStatus;
    [SerializeField]
    private Transform playerTrans;
    private GameObject skillShield;
    public void Skill_ShieldStart()
    {
        skillShield = playerStatus.skillShield;
        skillShield.SetActive(true);
        skillShield.transform.position = playerTrans.position;
        skillShield.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        skillShield.transform.parent = playerTrans;
        skillShield.GetComponent<ShieldProcess>().ShieldOn();
    }

    public void Skill_ReviveShieldStart()
    {
        skillShield = playerStatus.skillReviveShield;
        skillShield.SetActive(true);
        skillShield.transform.position = playerTrans.position;
        skillShield.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        skillShield.transform.parent = playerTrans;
        skillShield.GetComponent<ShieldProcess>().ShieldOn();
    }

    public void Skill_BombStart()
    {
        // 추가 예정.
    }
    
}
