using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject monsterGroups;
    private MonstersGroup[] monsterPrefabGroup;
    [SerializeField]
    private float spwanTime = 1.0f;
    [SerializeField]
    private Transform genPosition0;
    [SerializeField]
    private Transform genPosition1;
    [SerializeField]
    private Transform genPosition2;

    [SerializeField]
    private Transform inGameMonsters;

    private IEnumerator monSpawnCoroutine;

    private int _maxMonsterNum = 0;
    public int maxMonsterNum
    {
        set { _maxMonsterNum = value; }
    }

    private List<List<GameObject>> monsterList;

    private int _curGameLevel = 0;
    public int curGameLevel
    {
        set { _curGameLevel = value; }
    }

    private Transform[] spwanPositions = new Transform[3];
    private GameLevel[] gameLevelGroups;

    public void Init(GameLevel[] levelGroup)
    {
        monSpawnCoroutine = MonSpawnProcess();
        gameLevelGroups = levelGroup;

        _maxMonsterNum = gameLevelGroups[0].gameMobMaxNum;
        _curGameLevel = gameLevelGroups[0].gameLevel;

        spwanPositions[0] = genPosition0;
        spwanPositions[1] = genPosition1;
        spwanPositions[2] = genPosition2;

        // 몬스터 프리팹그룹의 각 인덱스는 게임레벨과 연동되어진다.
        monsterPrefabGroup = monsterGroups.GetComponentsInChildren<MonstersGroup>();
        int allLevelCnt = monsterPrefabGroup.Length;
        monsterList = new List<List<GameObject>>();

        for (int idx = 0; idx < allLevelCnt; ++idx)
        {
            monsterList.Add(new List<GameObject>());
            CreateMonster(idx, gameLevelGroups[idx].gameMobMaxNum);
        }
        StartMonSpawn();
    }

    public void StartMonSpawn() { StartCoroutine(monSpawnCoroutine); }
    public void StopMonSpawn() { StopCoroutine(monSpawnCoroutine); }

    //public void AddMonsterNum() { if (curMonsterNum < maxMonsterNum) curMonsterNum++; }
    //public void SubMonsterNum() { if (curMonsterNum > 0) curMonsterNum--; }

    IEnumerator MonSpawnProcess()
    {
        int idx = 0;
        while(true)
        {
            yield return new WaitForSeconds(spwanTime);
            if (idx >= _maxMonsterNum) idx = 0;
            if (monsterList[_curGameLevel][idx].activeSelf == true)
            {
                idx++;
                continue;
            }
            monsterList[_curGameLevel][idx].SetActive(true);
            monsterList[_curGameLevel][idx].transform.position = spwanPositions[Random.Range(0, 3)].position;
            monsterList[_curGameLevel][idx].GetComponent<Zombie>().ReSet();
            idx++;
        }
    }

    private void CreateMonster(int gameLevel, int maxCreateNum)
    {
        for (int curMonsterNum = 0; curMonsterNum < maxCreateNum; curMonsterNum++)
        {
            int randomNum = Random.Range(0, 3);
            GameObject prefab = monsterPrefabGroup[gameLevel].GetMonster((MonstersGroup.MONSTER_TYPE)randomNum);
            GameObject monster = Instantiate(prefab, 
                new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            monster.GetComponent<Zombie>().Init();
            monster.SetActive(false);
            monster.transform.parent = inGameMonsters;
            monsterList[gameLevel].Add(monster);
        }
    }
}
