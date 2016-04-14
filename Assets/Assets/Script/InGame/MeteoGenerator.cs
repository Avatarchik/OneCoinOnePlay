using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteoGenerator : MonoBehaviour {

    private EffectSettings[] meteoList;
    [SerializeField]
    private GameObject meteoGroup;
    private int meteoMaxNumber = 16;

    private float _genTime;
    public float genTime
    {
        set { _genTime = value; }
    }

    private IEnumerator genProcess;
    

    public void Init()
    {
        meteoList = meteoGroup.GetComponentsInChildren<EffectSettings>();
        genProcess = MeteoGenerateProcess();

        for(int idx = 0; idx < meteoMaxNumber; ++idx)
        {
            meteoList[idx].EffectDeactivated += (object sender, System.EventArgs e) =>
                {
                    Debug.Log("deActivate!");
                };
        }
    }

    public IEnumerator MeteoGenerateProcess()
    {
        while(true)
        {
            yield return new WaitForSeconds(_genTime);
        }
    }
}
