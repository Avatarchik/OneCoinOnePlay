using UnityEngine;
using System.Collections;

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

        StartGenerate();
    }

    public void SetMaxMonsterNum(int _maxNum) { maxMonsterNum = _maxNum; }

    public void StartGenerate() { StartCoroutine(GenProcess()); }
    public void StopGenerate() { StopCoroutine(GenProcess()); }

    public void AddMonsterNum() { if (curMonsterNum < maxMonsterNum) curMonsterNum++; }
    public void SubMonsterNum() { if (curMonsterNum > 0) curMonsterNum--; }

    IEnumerator GenProcess()
    {
        while(true)
        {
            yield return new WaitForSeconds(spwanTime);
            if(curMonsterNum < maxMonsterNum)
            {
                CreateMonster();
            }
        }
    }

    private void CreateMonster()
    {
        int randomNum = Random.Range(0, 3); 
        GameObject prefab = monsterPrefabGroup[curGameLevel].GetMonster((MonstersGroup.MONSTER_TYPE)randomNum);
        Instantiate(prefab, spwanPositions[Random.Range(0, 3)].position,
               new Quaternion(0, 0, 0, 0));
        AddMonsterNum();
    }
}
