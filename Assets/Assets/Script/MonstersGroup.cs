using UnityEngine;
using System.Collections;

public class MonstersGroup : MonoBehaviour {

    [SerializeField]
    private GameObject normalMonsterPrefab;
    [SerializeField]
    private GameObject advacedMonsterPrefab;
    [SerializeField]
    private GameObject championMonsterPrefab;

    [HideInInspector]
    public enum MONSTER_TYPE
    {
        NORMAL,
        ADVANCED,
        CHAMPION
    }
    public GameObject GetMonster(MONSTER_TYPE _type)
    {
        switch(_type)
        {
            case MONSTER_TYPE.NORMAL:
                return normalMonsterPrefab;
            case MONSTER_TYPE.ADVANCED:
                return advacedMonsterPrefab;
            case MONSTER_TYPE.CHAMPION:
                return championMonsterPrefab;
            default:
                return null;
        }
    }
}
