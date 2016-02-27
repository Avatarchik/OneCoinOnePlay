using UnityEngine;
using System.Collections;

public class GameMessage : MonoBehaviour {

    [SerializeField]
    private UILabel lbl_gameMsg;
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
    }

    public void CloseMessage()
    {
        lbl_gameMsg.gameObject.SetActive(false);
    }
}
