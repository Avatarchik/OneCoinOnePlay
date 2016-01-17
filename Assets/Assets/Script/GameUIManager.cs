using UnityEngine;
using System.Collections;

/// <summary>
/// 게임의 UI를 관리하는 매니저.
/// </summary>
public class GameUIManager : MonoBehaviour {

    [SerializeField]
    private PlayerAttackManager playerAtkMgr;
    [SerializeField]
    private PlayerSkillManager playerSkillMgr;
    [SerializeField]
    private UIButton btn_SkillShield;
    [SerializeField]
    private UIButton btn_SkillBomb;

    
    public void ClickAttackBtn()
    {
        playerAtkMgr.AttackInit();
    }
    
    public void ClickSkill_SheildBtn()
    {
        btn_SkillShield.isEnabled = false;
        playerSkillMgr.Skill_ShieldStart();
    }
}
