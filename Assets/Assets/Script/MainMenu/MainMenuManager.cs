using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MainMenuManager : MonoBehaviour {

    void Start()
    {
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }

	public void GameStart()
    {
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if(success)
            {
                SceneManager.LoadSceneAsync("InGame");
            }
            else
            {
                
            }
            
        });
        
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
