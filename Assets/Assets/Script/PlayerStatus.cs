using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    private PLAYER_MAGIC_TYPE curPlayerMagic = PLAYER_MAGIC_TYPE.NORMAL_SHOT;
    [HideInInspector]
    public enum PLAYER_MAGIC_TYPE
    {
        NORMAL_SHOT,
        ADVANCED_SHOT
    }
    //public PLAYER_MAGIC_TYPE GetCurPlayerMagic() { return curPlayerMagic; }
    public void SetCurPlayerMagic(PLAYER_MAGIC_TYPE _type) { curPlayerMagic = _type; }
   

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
}
