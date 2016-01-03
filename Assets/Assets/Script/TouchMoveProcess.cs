using UnityEngine;
using System.Collections;

// 쿼터뷰 터치이동 스크립트.
// 캐릭터 이동은 CharacterController 컴포넌트 활용.

public class TouchMoveProcess : MonoBehaviour
{

    private Ray screenToTouch;
    private RaycastHit rayCastHit;

    [SerializeField]
    private Camera view_Camera;

    [SerializeField]
    private CharacterController chController;

    // player to touchPoint
    private Vector3 dirVector;
    
	void Update ()
    {

        if (Input.touchCount == 0) return;
        screenToTouch = view_Camera.ScreenPointToRay(Input.GetTouch(0).position);

        TouchPhase touchPhase = Input.GetTouch(0).phase;
        switch (touchPhase)
        {
            case TouchPhase.Began:
                {
                    // to do
                }
                break;
            case TouchPhase.Moved:
                {
                    MoveCharacter();
                    RotateCharacter();
                }
                break;
            case TouchPhase.Stationary:
                {
                    MoveCharacter();
                    RotateCharacter();
                }
                break;

            case TouchPhase.Ended:
                {

                }
                break;
            case TouchPhase.Canceled:
                {

                }
                break;
        }

    }

    private void MoveCharacter()
    {
        if (CalcDirVector()) chController.Move(dirVector * Time.deltaTime * 2.0f);
        else return;
    }

    private bool CalcDirVector()
    {
        if (Physics.Raycast(screenToTouch, out rayCastHit))
        {
            Vector3 touchPoint = rayCastHit.point;
            dirVector = touchPoint - gameObject.transform.position;
            dirVector.Normalize();

            return true;
        }
        else
            return false;
    }

    private void RotateCharacter()
    {
        if (CalcDirVector())
        {
            Quaternion endRotation = Quaternion.LookRotation(dirVector, Vector3.up);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
                endRotation,
                Time.deltaTime * 2.0f);
        }
        else return;
    }

}
