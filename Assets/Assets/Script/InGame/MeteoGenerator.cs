using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteoGenerator : MonoBehaviour {
    [SerializeField]
    private GameObject[] meteoList;
   
    private int meteoMaxNumber = 16;

    private float _genTime;
    public float genTime
    {
        set { _genTime = value; }
    }

    private int _genMeteoNum;
    public int genMeteoNum
    {
        set { _genMeteoNum = value; }
    }

    private IEnumerator genProcess;
    

    public void Init()
    {
        genProcess = MeteoGenerateProcess();

        for(int idx = 0; idx < meteoMaxNumber; ++idx)
        {
            EffectSettings settings = meteoList[idx].GetComponent<EffectSettings>();
            settings.EffectDeactivated += (object sender, System.EventArgs e) =>
                {
                    EffectEventArgsData arg = e as EffectEventArgsData;
                    int meteoIdx = int.Parse(arg.objName);
                    Vector3 pos = meteoList[meteoIdx].transform.position;
                    pos.y = 10;
                    meteoList[meteoIdx].transform.position = pos;
                };
        }
    }

    public void StartGenMeteoProcess()
    {
        StartCoroutine(genProcess);
    }
    public void StopGenMeteoProcess()
    {
        StopCoroutine(genProcess);
    }

    public IEnumerator MeteoGenerateProcess()
    {
        while(true)
        {
            for(int idx = 0; idx < _genMeteoNum; ++idx)
            {
                meteoList[Random.Range(0, 16)].SetActive(true);
            }
            yield return new WaitForSeconds(_genTime);
        }
    }
}
