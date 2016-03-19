using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

        iTween.ColorTo(gameObject,
                       iTween.Hash("color", new Color(0.2f, 0.1f, 0.5f, 0.1f),
                       "time", 0.5f,
                       "looptype", iTween.LoopType.loop));
    }


}
