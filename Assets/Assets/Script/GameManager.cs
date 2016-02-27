using UnityEngine;
using System.Collections;

/// <summary>
/// 게임의 흐름을 관리하는 게임매니저.
/// </summary>
public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameDifficulty gameDiffLevel;
    [SerializeField]
    private MonsterGenerator gameMonGenerator;
    [SerializeField]
    private GameTimer gameTimer;
    [SerializeField]
    private GameMessage gameMessage;

    private GameLevel[] arr_gameLevel;
    private int curGameDiffLevel = 0;

	// Use this for initialization
	void Start ()
    {
        gameTimer.InitGameTimer();

        gameDiffLevel.Init();
        arr_gameLevel = gameDiffLevel.gameLevelData;
        curGameDiffLevel = arr_gameLevel[0].gameLevel;
        
        gameMonGenerator.Init(arr_gameLevel[0].gameMobMaxNum,
                              arr_gameLevel[0].gameLevel);
    }

    private IEnumerator GameLevelController()
    {
        double curTotSec = 0.0f;
        while(true)
        {
            curTotSec = gameTimer.gameTime.GetSec();

            if ((curTotSec > 0.0f) && (curTotSec <= 30.0f)) { }
            else if ((curTotSec > 30.0f) && (curTotSec <= 60.0f)) { }
            else if ((curTotSec > 60.0f) && (curTotSec <= 90.0f)) { }
            else if ((curTotSec > 90.0f) && (curTotSec <= 120.0f)) { }
            else if ((curTotSec > 120.0f) && (curTotSec <= 150.0f)) { }
            else if ((curTotSec > 150.0f) && (curTotSec <= 180.0f)) { }
            else if ((curTotSec > 180.0f) && (curTotSec <= 210.0f)) { }

            yield return null;
        }
    }

    private bool isLevel2 = false;
    private void Level2Start()
    {
        if(isLevel2 == false)
        {

        }
    }

    private void SetGameLevel(int level, int maxMobNum, string msg)
    {
        
    }
	
}
