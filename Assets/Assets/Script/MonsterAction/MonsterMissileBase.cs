using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class MonsterMissileBase : MonoBehaviour {

    [SerializeField]
    private EffectSettings missileEffectSettings;
    [SerializeField]
    private ProjectileCollisionBehaviour pColl;

    [HideInInspector]
    public enum MISSILE_DIRECTION
    {
        NONE = 0,
        NORTH = 1,
        SOUTH = 2,
        WEST = 3,
        EAST = 4,
        SOUTH_EAST = 5,
        SOUTH_WEST = 6,
        NORTH_EAST = 7,
        NORTH_WEST = 8
    }
    public MISSILE_DIRECTION monsterMissileDir;
    private Vector3 dirVector;
    private readonly float speed = 0.05f;

    private IEnumerator moveProcessRoutine;

    private Vector3 playerPos;

    public void StartMissile (Vector3 _playerPos)
    {
        playerPos = _playerPos;
        InitMissilePos();
        CalcDirVector();
        moveProcessRoutine = MoveProcess();
        StartCoroutine(moveProcessRoutine);
    }

    private void InitMissilePos() { transform.position = playerPos; }

    private void CalcDirVector()
    {
        switch (monsterMissileDir)
        {
            case MISSILE_DIRECTION.NORTH:
                dirVector.x = 0.0f;
                dirVector.z = speed;
                break;
            case MISSILE_DIRECTION.SOUTH:
                dirVector.x = 0.0f;
                dirVector.z = -speed;
                break;
            case MISSILE_DIRECTION.WEST:
                dirVector.x = speed;
                dirVector.z = 0.0f;
                break;
            case MISSILE_DIRECTION.EAST:
                dirVector.x = -speed;
                dirVector.z = 0.0f;
                break;
            case MISSILE_DIRECTION.NORTH_EAST:
                dirVector.x = -speed;
                dirVector.z = speed;
                break;
            case MISSILE_DIRECTION.NORTH_WEST:
                dirVector.x = speed;
                dirVector.z = speed;
                break;
            case MISSILE_DIRECTION.SOUTH_EAST:
                dirVector.x = speed;
                dirVector.z = -speed;
                break;
            case MISSILE_DIRECTION.SOUTH_WEST:
                dirVector.x = -speed;
                dirVector.z = -speed;
                break;
            default:
                break;
        }
    }

    IEnumerator MoveProcess()
    {
        while (true)
        {
            gameObject.transform.position += dirVector;
            yield return null;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        missileEffectSettings.Target = collision.transform;
        pColl.Start();
        StopCoroutine(moveProcessRoutine);
    }
}
