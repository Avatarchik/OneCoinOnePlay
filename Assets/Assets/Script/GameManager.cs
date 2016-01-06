using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameDifficulty gameDiffLevel;
    [SerializeField]
    private MonsterGenerator monGenerator;

    private GameLevel[] arr_gameLevel;
    private int curGameDiffLevel = 0;

	// Use this for initialization
	void Start ()
    {

        gameDiffLevel.Init();
        arr_gameLevel = gameDiffLevel.GetLevelData();
        curGameDiffLevel = arr_gameLevel[0].GetLevel();

        monGenerator.Init(10, 0);
	}
	
}
