using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public struct GameTime
{
    private Stopwatch stopWatch;
    private TimeSpan timeSpan;
    public void InitTime()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }

    public string GetFormatTime()
    {
        timeSpan = stopWatch.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}.{2:00}",
            timeSpan.Minutes, timeSpan.Seconds,
            timeSpan.Milliseconds / 10);

        return elapsedTime;
    }

    public double GetSec()
    {
        timeSpan = stopWatch.Elapsed;
        return timeSpan.TotalSeconds;
    }
    public void StartStopWatch() { stopWatch.Start(); }
    public void EndStopWatch() { stopWatch.Stop(); }
}

public class GameTimer : MonoBehaviour
{

    [SerializeField]
    private UILabel lbl_gameTime;
    private GameTime _gameTime;
    public GameTime gameTime
    {
        get { return _gameTime; }
    }
    IEnumerator gameTimeCoRoutine;

    private bool isTimerOn = false;

    public void InitGameTimer()
    {
        _gameTime.InitTime();
        gameTimeCoRoutine = TimeProcess();
        isTimerOn = true;
        StartCoroutine(gameTimeCoRoutine);
	}
    public void StopGameTimer()
    {
        isTimerOn = false;
        _gameTime.EndStopWatch();
        StopCoroutine(gameTimeCoRoutine);
    }
    public void ReStartGameTimer()
    {
        isTimerOn = true;
        _gameTime.StartStopWatch();
        StartCoroutine(gameTimeCoRoutine);
    }

    IEnumerator TimeProcess()
    {
        while(isTimerOn)
        {
            lbl_gameTime.text = _gameTime.GetFormatTime();
            yield return null;
        }
    }
}
