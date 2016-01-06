using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLevel
{
    private string gamelevelName;
    private int gameLevel;
    private int gameMobMaxNum;

    public void SetLevelName(string _name) { gamelevelName = _name; }
    public string GetLevelName() { return gamelevelName; }
    
    public void SetLevel(int _lev) { gameLevel = _lev; }
    public int GetLevel() { return gameLevel; }

    public void SetMobMaxNum(int _maxNum) { gameMobMaxNum = _maxNum; }
    public int GetMobMaxNum() { return gameMobMaxNum; }

}

public class GameDifficulty : MonoBehaviour {

    private JSONObject gameDiffJsonObj;
    private TextAsset gameDifftextFile;
    /// <summary>
    ///  example) jsonDataSheet[0] 0번 레벨(=난이도),
    ///           jsonDataSheet[0].TryGetValue(x,x) 0번 레벨의 세부내용 접근.
    /// </summary>
    private List<Dictionary<string, string>> jsonDataSheet;
    private GameLevel[] gameLevelData;
    public GameLevel[] GetLevelData() { return gameLevelData; }

    public void Init()
    {
        jsonDataSheet = new List<Dictionary<string, string>>();
        gameDifftextFile = Resources.Load("textAssets/gameDiff") as TextAsset;

        gameDiffJsonObj = new JSONObject(gameDifftextFile.text);
        AccessData(gameDiffJsonObj);

        int maxGameLevel = jsonDataSheet.Count;
        gameLevelData = new GameLevel[maxGameLevel];
        for(int idx = 0; idx < jsonDataSheet.Count; ++idx)
        {
            gameLevelData[idx] = new GameLevel();
            string levelName;
            jsonDataSheet[idx].TryGetValue("levelName", out levelName);
            string level;
            jsonDataSheet[idx].TryGetValue("level", out level);
            string mobMaxNum;
            jsonDataSheet[idx].TryGetValue("mobMaxNum", out mobMaxNum);
           
            gameLevelData[idx].SetLevelName(levelName);
            gameLevelData[idx].SetLevel(int.Parse(level));
            gameLevelData[idx].SetMobMaxNum(int.Parse(mobMaxNum));

            
            

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
