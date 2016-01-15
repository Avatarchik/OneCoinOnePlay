using UnityEngine;
using System.Collections;

public class ShieldProcess : MonoBehaviour {

    private float remainTime = 10.0f;
    private IEnumerator startProcessCoRoutine;

    public void ShieldOn ()
    {
        startProcessCoRoutine = StartProcess();
        StartCoroutine(startProcessCoRoutine);
	}
	
    IEnumerator StartProcess()
    {
        while(true)
        {
            if (remainTime <= 0.0f)
            {
                remainTime = 10.0f;
                gameObject.SetActive(false);
                break;
            }
            else remainTime -= 1.0f;

            yield return new WaitForSeconds(1.0f);
        }
    }
    
}
