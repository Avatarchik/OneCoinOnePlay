using UnityEngine;
using System.Collections;
/// <summary>
/// 플레이어의 상태를 나타낸다.
/// -> ex: 사용중인 미사일 종류, 생명력의 상태 등 .. etc.
/// </summary>
public class PlayerStatus : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject;
    
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private PlayerEffectManager playerEffectMgr;

    private delegate void PlayerDeadProcess();
    private PlayerDeadProcess del_deadProcess;
    private delegate void PlayerReviveProcess();
    private PlayerReviveProcess del_reviveProcess;
    void Start()
    {
        del_reviveProcess = gameManager.GameReStart;
        del_deadProcess = gameManager.GameStop;
    }

    private PLAYER_MAGIC_TYPE curPlayerMagic = PLAYER_MAGIC_TYPE.NORMAL_SHOT;
    [HideInInspector]
    public enum PLAYER_MAGIC_TYPE
    {
        NORMAL_SHOT,
        ADVANCED_SHOT
    }
    //public PLAYER_MAGIC_TYPE GetCurPlayerMagic() { return curPlayerMagic; }
    //public void SetCurPlayerMagic(PLAYER_MAGIC_TYPE _type) { curPlayerMagic = _type; }

    [SerializeField]
    private GameObject shot0;
    [SerializeField]
    private GameObject shot1;
    public GameObject GetPlayerShot()
    {
        if (curPlayerMagic == PLAYER_MAGIC_TYPE.NORMAL_SHOT)
            return shot0;
        else if (curPlayerMagic == PLAYER_MAGIC_TYPE.ADVANCED_SHOT)
            return shot1;
        else
            return null;
    }

    [SerializeField]
    private GameObject _skillShield;
    public GameObject skillShield
    {
        get { return _skillShield; }
    }
    [SerializeField]
    private GameObject _skillBomb;
    public GameObject skillBomb
    {
        get { return _skillBomb; }
    }
    [SerializeField]
    private GameObject _skillReviveShield;
    public GameObject skillReviveShield
    {
        get { return _skillReviveShield; }
    }

    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        set
        {
            _isDead = value;
            if (value)
            {
                playerEffectMgr.DeadEffectOn();
                playerObject.SetActive(false);
                del_deadProcess();
            }
            else
            {
                CharacterController chController = playerObject.GetComponent<CharacterController>();

                playerEffectMgr.ReviveEffectOn();
                playerObject.SetActive(true);
                chController.detectCollisions = false;
                playerObject.GetComponent<PlayerSkillManager>().Skill_ReviveShieldStart();
                chController.detectCollisions = true;
                del_reviveProcess();
            }
        }
    }
    

}
