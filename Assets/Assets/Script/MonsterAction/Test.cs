using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

        iTween.ColorTo(gameObject,
                       iTween.Hash("color", Color.yellow,
                       "time", 2.0f,
                       "looptype", iTween.LoopType.loop));
	}
	
	
}
