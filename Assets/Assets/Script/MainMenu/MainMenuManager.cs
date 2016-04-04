using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MainMenuManager : MonoBehaviour {

    private bool isLoginSuccess = false;

    void Start()
    {
        InitGPG();
        LogingGPG();
    }

    public void InitGPG()
    {
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }

    public void LogingGPG()
    {
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if (success)
            {
                isLoginSuccess = true;
            }
            else
            {
                isLoginSuccess = false;
            }
        });
    }

	public void GameStart()
    {
        if(isLoginSuccess)
        {
            SceneManager.LoadSceneAsync("InGame");
        }
        else
        {
            LogingGPG();
        }
        
    }

    public void OnClickLeaderBoard()
    {
        // show leaderboard UI
        Social.ShowLeaderboardUI();
    }

    public void OnClickAchivement()
    {
        // show achievements UI
        Social.ShowAchievementsUI();
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
