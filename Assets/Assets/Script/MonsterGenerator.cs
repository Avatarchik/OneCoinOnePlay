using UnityEngine;
using System.Collections;

public class MonsterGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject monsterPrefab0;
    [SerializeField]
    private float genTime = 1.0f;
    [SerializeField]
    private Transform genPosition0;
    [SerializeField]
    private Transform genPosition1;
    [SerializeField]
    private Transform genPosition2;
    [SerializeField]
    private int maxMonsterNum = 5;
    private int curMonsterNum = 0;

    private Transform[] arrPositions = new Transform[3];

    void Start()
    {
        arrPositions[0] = genPosition0;
        arrPositions[1] = genPosition1;
        arrPositions[2] = genPosition2;
        StartGenerate();
    }

    public void StartGenerate()
    {
        StartCoroutine(GenProcess());
    }

    public void StopGenerate()
    {
        StopCoroutine(GenProcess());
    }

    public void AddMonsterNum()
    {
        if (curMonsterNum < maxMonsterNum) curMonsterNum++;
    }
    public void SubMonsterNum()
    {
        if (curMonsterNum > 0) curMonsterNum--;
    }

    IEnumerator GenProcess()
    {
        while(true)
        {
            yield return new WaitForSeconds(genTime);
            if(curMonsterNum < maxMonsterNum)
            {
                Instantiate(monsterPrefab0, arrPositions[Random.Range(0,3)].position,
                new Quaternion(0, 0, 0, 0));
                AddMonsterNum();
            }
        }
    }
}
