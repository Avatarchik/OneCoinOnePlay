using UnityEngine;
using System.Collections;

// 쿼터뷰 터치이동 스크립트.
// 캐릭터 이동은 CharacterController 컴포넌트 활용.

public class TouchMoveProcess : MonoBehaviour
{

    private Ray screenRay;
    private RaycastHit rayCastHit;
    private Vector3 screenToWorldPoint;

    [SerializeField]
    private Camera view_Camera;

    [SerializeField]
    private CharacterController chController;
    [SerializeField]
    private Animator chAnimator;

    [SerializeField]
    private GameObject joyStickBack;
    private float radiusOfJoyStickBack;
    [SerializeField]
    private GameObject joyStickFront;

    private Vector3 dirVector;
    private float moveSpeed = 1.5f;
    private float joyStickSpeed = 3.0f;

    private Vector3 startPointXZ;
    private Vector3 endPointXZ;
    private enum POINT_TYPE
    {
        START_POINT,
        END_POINT
    }

    private int screenHalfWidth;
    
    void Start()
    {
        UISprite spr = joyStickBack.GetComponent<UISprite>();
        radiusOfJoyStickBack = spr.width / 2;
        screenHalfWidth = Screen.width / 2;
    }

	void Update ()
    {
        if (Input.touchCount == 0) return;
        Vector2 touchPoint = Input.GetTouch(0).position;
        if (touchPoint.x > screenHalfWidth) return;
        screenRay = view_Camera.ScreenPointToRay(touchPoint);
        screenToWorldPoint = view_Camera.ScreenToWorldPoint(touchPoint);
       
        TouchPhase touchPhase = Input.GetTouch(0).phase;
        switch (touchPhase)
        {
            case TouchPhase.Began:
                {
                    //JoyStickPosInit();
                    CalcScreenToWorldPoint(POINT_TYPE.START_POINT);
                    FollowTouchPoint();
                }
                break;
            case TouchPhase.Moved:
                {
                    CalcScreenToWorldPoint(POINT_TYPE.END_POINT);
                    FollowTouchPoint();
                    RotateCharacter();
                    MoveCharacter();
                }
                break;
            case TouchPhase.Stationary:
                {
                    CalcScreenToWorldPoint(POINT_TYPE.END_POINT);
                    FollowTouchPoint();
                    RotateCharacter();
                    MoveCharacter();
                }
                break;

            case TouchPhase.Ended:
                {
                    StopCharacter();
                    JoyStickRePos();
                }
                break;
            case TouchPhase.Canceled:
                {
                    StopCharacter();
                    JoyStickRePos();
                }
                break;
        }

    }

    private void CalcScreenToWorldPoint(POINT_TYPE _TYPE)
    {
        switch(_TYPE)
        {
            case POINT_TYPE.START_POINT:
                startPointXZ = screenToWorldPoint;
                startPointXZ.z = startPointXZ.y;
                startPointXZ.y = 0.0f;
                break;
            case POINT_TYPE.END_POINT:
                endPointXZ = screenToWorldPoint;
                endPointXZ.z = endPointXZ.y;
                endPointXZ.y = 0.0f;
                break;
            default:
                //Debug.Log("POINT_TYPE_ERROR");
                break;
        }
    }

    private void MoveCharacter()
    {
        CalcDirVector();
        chController.Move(dirVector * Time.deltaTime * moveSpeed);
        chAnimator.SetBool("Moving", true);
        chAnimator.SetBool("Running", true);
    }

    private void StopCharacter()
    {
        chAnimator.SetBool("Moving", false);
        chAnimator.SetBool("Running", false);
    }

    private bool CalcDirVector()
    {
        if (Physics.Raycast(screenRay, out rayCastHit))
        {
            //calculate for dirVector in XZ plane
            dirVector = endPointXZ - startPointXZ;
            dirVector.Normalize();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void RotateCharacter()
    {
        if (CalcDirVector())
        {
            Quaternion endRotation = Quaternion.LookRotation(dirVector, Vector3.up);
            gameObject.transform.rotation = endRotation;
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
            //    endRotation,
            //    Time.deltaTime * 2.0f);

        }
    }

    /// <summary>
    /// 터치시마다 가상 조이스틱 위치를 해당 지점으로 초기화한다. ( Don't use )
    /// </summary>
    private void JoyStickPosInit()
    {
        joyStickFront.transform.position = screenToWorldPoint;
        joyStickBack.transform.position = screenToWorldPoint;
    }

    private void JoyStickRePos()
    {
        joyStickFront.transform.position = joyStickBack.transform.position;
    }

    private void FollowTouchPoint()
    {
        if (Physics.Raycast(screenRay, out rayCastHit)) 
        {
            Vector3 frontBackUpPos = joyStickFront.transform.position;
            Vector3 touchToPosition = Vector3.Lerp(joyStickFront.transform.position,
                rayCastHit.point, Time.deltaTime * joyStickSpeed);
            if (ChkMovableJoyStick(touchToPosition))
                joyStickFront.transform.position = touchToPosition;
            else
                joyStickFront.transform.position = frontBackUpPos;
        }
    }
    private bool ChkMovableJoyStick(Vector3 _toWorldPoint)
    {
        Vector3 startVec = joyStickBack.transform.position;
        Vector3 endVec = _toWorldPoint;
        float distance = Vector3.Distance(startVec, endVec);

        if (distance <= radiusOfJoyStickBack) return true;
        else return false;
    }

}
