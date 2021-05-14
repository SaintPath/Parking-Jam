using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

// Input.GetTouch example.
//
// Attach to an origin based cube.
// A screen touch moves the cube on an iPhone or iPad.
// A second screen touch reduces the cube size.

public class Swipe : MonoBehaviour
{
    [SerializeField] bool carVertical;
    private Vector3 InitialPosition;
    private Vector3 EndingPosition;
    private RaycastHit hit;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    Physics.Raycast(touchRay, out hit);
                    if (GetComponent<Collider>() == hit.collider)
                    {
                        InitialPosition = touch.position;
                    }
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    if (GetComponent<Collider>() == hit.collider)
                    {
                        EndingPosition = touch.position;
                        if (carVertical)
                        {
                            if (InitialPosition.y < EndingPosition.y)
                            {
                                GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -50));
                            }
                            else if (InitialPosition.y > EndingPosition.y)
                            {
                                GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50));
                            }
                        }
                        else
                        {
                            if (InitialPosition.x < EndingPosition.x)
                            {
                                GetComponent<Rigidbody>().AddForce(new Vector3(-50, 0, 0));
                            }
                            else if (InitialPosition.x > EndingPosition.x)
                            {
                                GetComponent<Rigidbody>().AddForce(new Vector3(50, 0, 0));
                            }
                        }

                    }
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }            
        }
    }
}