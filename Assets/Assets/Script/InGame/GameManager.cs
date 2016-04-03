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
    [SerializeField]
    private GameUIManager uiManager;

    private GameLevel[] arr_gameLevel;
    private int curGameDiffLevel = 0;

	// Use this for initialization
	void Start ()
    {
        GameInit();
    }

    private void GameInit()
    {
        gameTimer.InitGameTimer();

        gameDiffLevel.Init();
        arr_gameLevel = gameDiffLevel.gameLevelData;
        curGameDiffLevel = arr_gameLevel[0].gameLevel;

        gameMonGenerator.Init(arr_gameLevel);

        StartCoroutine(GameLevelController());
    }

    public void GameStart()
    {
        gameTimer.ReStartGameTimer();
        gameMonGenerator.StartMonSpawn();
    }

    public void GameStop()
    {
        uiManager.PopupDieMenu();
        gameTimer.StopGameTimer();
        gameMonGenerator.StopMonSpawn();
    }

    private IEnumerator GameLevelController()
    {
        double curTotSec = 0.0f;
        while(true)
        {
            curTotSec = gameTimer.gameTime.GetSec();
            if ((curTotSec > 0.0f) && (curTotSec <= 30.0f)) { Level0Start(); }
            else if ((curTotSec > 30.0f) && (curTotSec <= 60.0f)) { Level1Start(); }
            else if ((curTotSec > 60.0f) && (curTotSec <= 90.0f)) { Level2Start(); }
            else if ((curTotSec > 90.0f) && (curTotSec <= 120.0f)) { Level3Start(); }
            else if ((curTotSec > 120.0f) && (curTotSec <= 150.0f)) { Level4Start(); }
            else if ((curTotSec > 150.0f) && (curTotSec <= 180.0f)) { Level5Start(); }
            else if ((curTotSec > 180.0f) && (curTotSec <= 210.0f)) { Level6Start(); }

            yield return null;
        }
    }
    
    private void SetGameLevel(int level, int maxMobNum, string msg)
    {
        gameMessage.message = msg;
        gameMessage.ShowMessage();
        gameMonGenerator.curGameLevel = level;
        gameMonGenerator.maxMonsterNum = maxMobNum;
        gameMonGenerator.StopMonSpawn();
        gameMonGenerator.StartMonSpawn();
    }

    private bool isLevel0 = false;
    private void Level0Start()
    {
        if (isLevel0 == true) return;
        SetGameLevel(arr_gameLevel[0].gameLevel,
                     arr_gameLevel[0].gameMobMaxNum,
                     arr_gameLevel[0].gameLevelName);
        isLevel0 = true;
    }
    private bool isLevel1 = false;
    private void Level1Start()
    {
        if (isLevel1 == true) return;
        SetGameLevel(arr_gameLevel[1].gameLevel, arr_gameLevel[1].gameMobMaxNum, "LEVEL 1 START");
        isLevel1 = true;
    }
    private bool isLevel2 = false;
    private void Level2Start()
    {
        if (isLevel2 == true) return;
        SetGameLevel(arr_gameLevel[2].gameLevel, arr_gameLevel[2].gameMobMaxNum, "LEVEL 2 START");
        isLevel2 = true;
    }
    private bool isLevel3 = false;
    private void Level3Start()
    {
        if (isLevel3 == true) return;
        SetGameLevel(arr_gameLevel[3].gameLevel, arr_gameLevel[3].gameMobMaxNum, "LEVEL 3 START");
        isLevel3 = true;
    }
    private bool isLevel4 = false;
    private void Level4Start()
    {
        if (isLevel4 == true) return;
        SetGameLevel(arr_gameLevel[4].gameLevel, arr_gameLevel[4].gameMobMaxNum, "LEVEL 4 START");
        isLevel4 = true;
    }
    private bool isLevel5 = false;
    private void Level5Start()
    {
        if (isLevel5 == true) return;
        SetGameLevel(arr_gameLevel[5].gameLevel, arr_gameLevel[5].gameMobMaxNum, "LEVEL 5 START");
        isLevel5 = true;
    }
    private bool isLevel6 = false;
    private void Level6Start()
    {
        if (isLevel6 == true) return;
        SetGameLevel(arr_gameLevel[6].gameLevel, arr_gameLevel[6].gameMobMaxNum, "LEVEL 6 START");
        isLevel6 = true;
    }
}
