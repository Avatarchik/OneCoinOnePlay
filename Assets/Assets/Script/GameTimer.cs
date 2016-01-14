using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public struct GameTime
{
    Stopwatch stopWatch;
    TimeSpan timeSpan;
    public void InitTime()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }

    public string GetTime()
    {
        timeSpan = stopWatch.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}.{2:00}",
            timeSpan.Minutes, timeSpan.Seconds,
            timeSpan.Milliseconds / 10);

        return elapsedTime;
    }

    public void EndStopWatch()
    {
        stopWatch.Stop();
    }

}

public class GameTimer : MonoBehaviour {

    [SerializeField]
    private UILabel lbl_gameTime;
    private GameTime gameTime;
    IEnumerator gameTimeCoRoutine;

    public void InitGameTimer()
    {
        gameTime.InitTime();
        gameTimeCoRoutine = TimeProcess();
        StartCoroutine(gameTimeCoRoutine);
	}
    public void EndGameTimer()
    {
        gameTime.EndStopWatch();
        StopCoroutine(gameTimeCoRoutine);
    }

    IEnumerator TimeProcess()
    {
        while(true)
        {
            lbl_gameTime.text = gameTime.GetTime();
            yield return null;
        }
    }
}
