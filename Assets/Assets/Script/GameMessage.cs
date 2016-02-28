using UnityEngine;
using System.Collections;

public class GameMessage : MonoBehaviour {

    [SerializeField]
    private UILabel lbl_gameMsg;
    [SerializeField]
    private TweenAlpha tweenAlpha;
    private string _message;
    public string message
    {
        set
        {
            _message = value;
            lbl_gameMsg.text = _message;
        }
    }

    public void ShowMessage()
    {
        lbl_gameMsg.gameObject.SetActive(true);
        StartCoroutine(CloseProcess());
    }

    private IEnumerator CloseProcess()
    {
        float waitTime = 3.0f;
        while(true)
        {
            if (waitTime <= 0) break;
            waitTime--;
            yield return new WaitForSeconds(1.0f);
        }
        CloseMessage();
    }

    public void CloseMessage()
    {
        lbl_gameMsg.gameObject.SetActive(false);
    }
}
