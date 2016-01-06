using UnityEngine;
using System.Collections;

public class MonstersGroup : MonoBehaviour {

    [SerializeField]
    private GameObject monsterPrefab;
    [SerializeField]
    private GameObject AdvacedMonsterPrefab;
    [SerializeField]
    private GameObject ChampionMonsterPrefab;

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
                return monsterPrefab;
            case MONSTER_TYPE.ADVANCED:
                return AdvacedMonsterPrefab;
            case MONSTER_TYPE.CHAMPION:
                return ChampionMonsterPrefab;
            default:
                return null;
        }
    }
}
