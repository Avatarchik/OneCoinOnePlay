using UnityEngine;
using System.Collections;

public class GameDifficulty : MonoBehaviour {

    JSONObject jsonObject;
    TextAsset jsonTextFile;

    void Start()
    {
        testInit();
    }

    public void testInit()
    {
        jsonTextFile = Resources.Load("textAssets/gameDiff") as TextAsset;

        string test = jsonTextFile.text;
        jsonObject = new JSONObject(test);
        

    }
}
