using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GPG_Controller : MonoBehaviour {
    
    public static void InitGPG()
    {
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }

    public static void LoginGPG()
    {
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if (success)
            {
               // to do  
            }
            else
            {
                // fail to login
            }
        });
    }

    public static void ShowAchievementUI()
    {
        // show achievements UI
        Social.ShowAchievementsUI();
    }

    public static void ShowLeaderBoardUI()
    {
        // show leaderboard UI
        Social.ShowLeaderboardUI();
    }

    public static void IncrementAchievement(string _achievementID)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(
            _achievementID, 1, (bool success) => {
            // handle success or failure
        });
    }
}
