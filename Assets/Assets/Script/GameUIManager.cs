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
    private UILabel lbl_shieldName;
    [SerializeField]
    private UILabel lbl_shieldTime;
    [SerializeField]
    private UIButton btn_SkillBomb;

    private readonly float intervalTime = 1.0f;
    private float sheildRemainTime = 30.0f;

    
    public void ClickAttackBtn()
    {
        playerAtkMgr.AttackInit();
    }
    
    public void ClickSkill_SheildBtn()
    {
        btn_SkillShield.isEnabled = false;
        playerSkillMgr.Skill_ShieldStart();
        StartCoroutine(SheildTimeProcess());
    }

    private IEnumerator SheildTimeProcess()
    {
        lbl_shieldName.gameObject.SetActive(false);
        lbl_shieldTime.gameObject.SetActive(true);
        while(true)
        {
            if (sheildRemainTime <= 0.0f) break;
            sheildRemainTime--;
            lbl_shieldTime.text = sheildRemainTime.ToString();
            yield return new WaitForSeconds(intervalTime);
        }
        lbl_shieldName.gameObject.SetActive(true);
        lbl_shieldTime.gameObject.SetActive(false);
        btn_SkillShield.isEnabled = true;
        sheildRemainTime = 30.0f;
    }
}
