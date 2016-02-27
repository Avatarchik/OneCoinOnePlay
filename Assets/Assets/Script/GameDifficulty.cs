using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLevel
{
    private string _gameLevelName;
    public string gameLevelName
    {
        get { return _gameLevelName; }
        set { _gameLevelName = value; }
    }
    private int _gameLevel;
    public int gameLevel
    {
        get { return _gameLevel; }
        set { _gameLevel = value; }
    }
    private int _gameMobMaxNum;
    public int gameMobMaxNum
    {
        get { return _gameMobMaxNum; }
        set { _gameMobMaxNum = value; }
    }
    
}

public class GameDifficulty : MonoBehaviour {

    private JSONObject gameDiffJsonObj;
    private TextAsset gameDifftextFile;
    /// <summary>
    ///  example) jsonDataSheet[0] 0번 레벨(=난이도),
    ///           jsonDataSheet[0].TryGetValue(x,x) 0번 레벨의 세부내용 접근.
    /// </summary>
    private List<Dictionary<string, string>> jsonDataSheet;
    private GameLevel[] _gameLevelData;
    public GameLevel[] gameLevelData
    {
        get { return _gameLevelData; } 
    }

    public void Init()
    {
        jsonDataSheet = new List<Dictionary<string, string>>();
        gameDifftextFile = Resources.Load("textAssets/gameDiff") as TextAsset;

        gameDiffJsonObj = new JSONObject(gameDifftextFile.text);
        AccessData(gameDiffJsonObj);

        int maxGameLevel = jsonDataSheet.Count;
        _gameLevelData = new GameLevel[maxGameLevel];
        for(int idx = 0; idx < jsonDataSheet.Count; ++idx)
        {
            _gameLevelData[idx] = new GameLevel();
            string levelName;
            jsonDataSheet[idx].TryGetValue("levelName", out levelName);
            string level;
            jsonDataSheet[idx].TryGetValue("level", out level);
            string mobMaxNum;
            jsonDataSheet[idx].TryGetValue("mobMaxNum", out mobMaxNum);

            _gameLevelData[idx].gameLevelName = levelName;
            _gameLevelData[idx].gameLevel = int.Parse(level);
            _gameLevelData[idx].gameMobMaxNum = int.Parse(mobMaxNum);

            
            

        }


    }
    
    private void AccessData(JSONObject jsonObj)
    {
        switch (jsonObj.type)
        {
            case JSONObject.Type.OBJECT:
                for(int idx=0; idx < jsonObj.Count; ++idx)
                {
                    JSONObject obj = jsonObj.list[idx];
                    AccessData(obj);
                }
                break;
            case JSONObject.Type.ARRAY:
                for(int idx = 0; idx < jsonObj.Count; ++idx)
                {
                    jsonDataSheet.Add(jsonObj.list[idx].ToDictionary());
                }
                break;
            default:
                Debug.Log("Json Level Data Sheet Access ERROR");
                break;
        }
    }
}
