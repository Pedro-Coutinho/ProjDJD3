using System.Collections.Generic;
using UnityEngine;



public class PlayerInteract : MonoBehaviour
{
    private const float MAX_INTERACTION_DISTANCE = 10f;

    //public CanvasMng canvasMng;

    private Transform           _cameraTransform;
    private Interactive         _currentInteractive;



    //void Start()
    //{
    //    _cameraTransform            = GetComponentInChildren<Camera>().transform;
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    CheckForInteractive();
    //    CheckForInteraction();
    //}

    //private void CheckForInteractive()
    //{
    //    if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hitInfo, MAX_INTERACTION_DISTANCE))
    //    {
    //        Interactive interactive = hitInfo.transform.GetComponent<Interactive>();

    //        if (interactive == null || interactive.type == Interactive.InteractiveType.Indirect)
    //            ClearCurrentInteractive();

    //        else if (interactive != _currentInteractive)
    //            SetCurrentInteractive(interactive);
    //    }

    //    else
    //        ClearCurrentInteractive();
    //}

    private void SetCurrentInteractive(Interactive interactive)
    {

    }

    private void ClearCurrentInteractive()
    {

    }

    private void CheckForInteraction()
    {

    }

    private void PickCurrentInteractive()
    {

    }

    private void InteractWithCurrentInteractive()
    {

    }
}