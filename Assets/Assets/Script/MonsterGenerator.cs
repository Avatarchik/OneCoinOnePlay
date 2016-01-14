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

    private int maxMonsterNum = 0;
    private int curMonsterNum = 0;
    private List<GameObject> monsterList = new List<GameObject>();
    private int curGameLevel = 0;
    public void SetCurGameLevel(int _level) { curGameLevel = _level; }

    private Transform[] spwanPositions = new Transform[3];

    public void Init(int _initMaxNum, int _initGameLevel)
    {
        maxMonsterNum = _initMaxNum;
        curGameLevel = _initGameLevel;

        spwanPositions[0] = genPosition0;
        spwanPositions[1] = genPosition1;
        spwanPositions[2] = genPosition2;
        monsterPrefabGroup = monsterGroups.GetComponentsInChildren<MonstersGroup>();

        CreateMonster();
        StartGenerate();
    }

    public void SetMaxMonsterNum(int _maxNum) { maxMonsterNum = _maxNum; }

    public void StartGenerate() { StartCoroutine(GenProcess()); }
    public void StopGenerate() { StopCoroutine(GenProcess()); }

    //public void AddMonsterNum() { if (curMonsterNum < maxMonsterNum) curMonsterNum++; }
    //public void SubMonsterNum() { if (curMonsterNum > 0) curMonsterNum--; }

    IEnumerator GenProcess()
    {
        int idx = 0;
        while(true)
        {
            yield return new WaitForSeconds(spwanTime);
            if (idx >= maxMonsterNum) idx = 0;
            if (monsterList[idx].activeSelf == true)
            {
                idx++;
                continue;
            }
            monsterList[idx].SetActive(true);
            monsterList[idx].transform.position = spwanPositions[Random.Range(0, 3)].position;
            monsterList[idx].GetComponent<Zombie>().Init();
            idx++;
        }
    }

    private void CreateMonster()
    {
        for (curMonsterNum = 0; curMonsterNum < maxMonsterNum; curMonsterNum++)
        {
            int randomNum = Random.Range(0, 3);
            GameObject prefab = monsterPrefabGroup[curGameLevel].GetMonster((MonstersGroup.MONSTER_TYPE)randomNum);
            GameObject monster = Instantiate(prefab, 
                new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            monster.SetActive(false);
            monsterList.Add(monster);
        }
    }
}
