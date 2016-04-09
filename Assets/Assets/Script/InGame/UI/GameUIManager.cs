using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임의 UI를 관리하는 매니저.
/// </summary>
public class GameUIManager : MonoBehaviour {

    [SerializeField]
    private PlayerStatus playerStatus;
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
    [SerializeField]
    private GameObject obj_popupMenu;
    [SerializeField]
    private GameObject obj_popupDieMenu;

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

    public void PopupMenu()
    {
        obj_popupMenu.SetActive(true);
        ScaleUpEffect(obj_popupMenu);
    }

    public void PopupDieMenu()
    {
        obj_popupDieMenu.SetActive(true);
        ScaleUpEffect(obj_popupDieMenu);
    }

    public void ClickOneMoreChance()
    {
        PopupCloseDieMenu();
        playerStatus.isDead = false;
    }

    public void PopupCloseMenu() { ScaleDownEffect("AfterCloseMenu", obj_popupMenu); }
    private void AfterCloseMenu() { obj_popupMenu.SetActive(false); }

    public void PopupCloseDieMenu() { ScaleDownEffect("AfterCloseDieMenu", obj_popupDieMenu); }
    private void AfterCloseDieMenu() { obj_popupDieMenu.SetActive(false); }

    private void ScaleUpEffect(GameObject popupObj)
    {
        popupObj.transform.localScale = new Vector3(0, 0, 0);
        Vector3 scaleUp = new Vector3(1, 1, 1);
        iTween.ScaleTo(popupObj, iTween.Hash("scale", scaleUp,
            "name", "scaleUp",
            "time", 1.0f,
            "speed", 10.0f,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.none));
    }
    private void ScaleDownEffect(string _callBack, GameObject popupObj)
    {
        popupObj.transform.localScale = new Vector3(1, 1, 1);
        Vector3 scaleDown = new Vector3(0, 0, 0);
        iTween.ScaleTo(popupObj, iTween.Hash("scale", scaleDown,
            "name", "scaleDown",
            "time", 1.0f,
            "speed", 10.0f,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.none,
            "oncomplete", _callBack,
            "oncompletetarget", gameObject));
    }


    public void ClickToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void ClickExitGame()
    {
        Application.Quit();
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
