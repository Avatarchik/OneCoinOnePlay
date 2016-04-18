using UnityEngine;
using System.Collections;

public class MissileTrapManager : MonoBehaviour {

    [SerializeField]
    private MissileTrapController[] missileTraps;

    public MissileTrapController GetTrap(int idx)
    {
        return missileTraps[idx];
    }
}
