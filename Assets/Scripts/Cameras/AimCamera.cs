
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AimCamera : MonoBehaviour
{
    public CinemachineVirtualCamera aimCamera;
    public Transform camera_Look;
    public Player playerData;
    public Camera mainCamera;
    public RectTransform AutoAimImage;
    public RectTransform CenterImage;
    public GameObject CameraNormal;
    public GameObject CameraAim;
    public GameObject CameraAim2;

    public GameObject player;

    private GameObject[] Enemies;

    public LayerMask layerMask;

    Vector3 screenPoint;
    private List<GameObject> enemysOnCameraView;
    private bool aiming = false;

    private GameObject _currentTarget = null;

    private GameObject CurrentClosetEnemy = null;

    //private bool lockedOnEnemy = false;
    private void Start()
    {
        
        enemysOnCameraView = new List<GameObject>();
        playerData.playerControls.Gameplay.Aim.performed += ctx => Aim();
        playerData.playerControls.Gameplay.Aim.canceled += ctx => CancelAim();
        playerData.playerControls.Gameplay.SwitchEnemy.performed += ctx => SwitchEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        CheckForEnemy();
        checkIntersection();
        autoAim();
    }

    private void autoAim()
    {
        float currentMinDist = Mathf.Infinity;
        
        foreach (GameObject enemy in Enemies)
        {
            screenPoint = mainCamera.WorldToViewportPoint(enemy.transform.position);
            var distance = (CenterImage.transform.position - mainCamera.WorldToScreenPoint(enemy.transform.position)).magnitude;

            // Add enemy if it is on screen view its not dead and it is in range.
            if ((screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) && enemysOnCameraView.Contains(enemy) == false
                && enemy.GetComponent<Enemy>().isDead == false && (enemy.transform.position - player.transform.position).magnitude < playerData.shootDist)
            {
                enemysOnCameraView.Add(enemy);
            }
            else if ((screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) == false || enemy.GetComponent<Enemy>().isDead == true 
                || (enemy.transform.position - player.transform.position).magnitude >= playerData.shootDist)
            {
                enemysOnCameraView.Remove(enemy);
            }

            // Closest enemy to center
            if (distance < currentMinDist && (enemy.transform.position - player.transform.position).magnitude < playerData.shootDist)
            {
                currentMinDist = distance;
                CurrentClosetEnemy = enemy;
            }
        }

        if (Enemies == null)
        {
            CurrentClosetEnemy = null;

        }

        // if (enemysOnCameraView.Count < 1)
        // {
        //     playerData.speed = 7;
        // }
        // else
        // {
        //     playerData.speed = 4.5f;
        // }


        // Working But needs to be better
        if (CurrentClosetEnemy != null)
        {
            if (enemysOnCameraView.Count != 0 && CurrentClosetEnemy != null && CurrentClosetEnemy.GetComponent<Enemy>().isDead == false 
                && (CurrentClosetEnemy.transform.position - player.transform.position).magnitude < playerData.shootDist)
            {
                AutoAimImage.transform.gameObject.SetActive(true);
                AutoAimImage.transform.position = mainCamera.WorldToScreenPoint(CurrentClosetEnemy.transform.position);
                if (aiming == false)
                {
                    aimCamera.LookAt = CurrentClosetEnemy.transform;
                    _currentTarget = CurrentClosetEnemy.transform.gameObject;
                }
            }
            else
            {
                AutoAimImage.transform.gameObject.SetActive(false);
            }

            if (CurrentClosetEnemy.GetComponent<Enemy>().isDead == true)
            {
                AutoAimImage.transform.gameObject.SetActive(false);
            }
        }
        
    }

    // Cancels aim if there is an obstacle between
    private void checkIntersection()
    {
        if (aiming && _currentTarget != null)
        {
            if (Physics.Linecast(mainCamera.transform.position, _currentTarget.transform.position, out RaycastHit hitInfo, ~layerMask))
            {
                CancelAim();
            }
        }
    }
    private void SwitchEnemy()
    {
        if (aiming)
        {

            int temp;
            int rnd;
            // Does while until the next target is difrent
            if (enemysOnCameraView.Count != 0)
            {
                do
                {
                    temp = enemysOnCameraView.Count;
                    rnd = Random.Range(0, temp);
                } while ((enemysOnCameraView[rnd] == _currentTarget) && enemysOnCameraView.Count > 1);
                playerData.currentEnemyPosition = enemysOnCameraView[rnd].transform.position;
                if (CameraAim.activeSelf == true)
                {
                    CameraAim2.GetComponent<CinemachineVirtualCamera>().LookAt = enemysOnCameraView[rnd].transform;
                    CameraAim2.SetActive(true);
                    CameraAim.SetActive(false);
                    _currentTarget = enemysOnCameraView[rnd];
                }
                else
                {
                    CameraAim.GetComponent<CinemachineVirtualCamera>().LookAt = enemysOnCameraView[rnd].transform;
                    CameraAim.SetActive(true);
                    CameraAim2.SetActive(false);
                    _currentTarget = enemysOnCameraView[rnd];
                }
            }

            if (enemysOnCameraView.Count < 1 || (_currentTarget.transform.position - player.transform.position).magnitude >= playerData.shootDist)
            {
                _currentTarget = null;
                CancelAim();
            }
            
            
            playerData.enemylock = true;

        }
        
    }

    // Aim at target
    private void Aim()
    {

        if (CurrentClosetEnemy != null && (CurrentClosetEnemy.transform.position - player.transform.position).magnitude < playerData.shootDist)
        {
            playerData.enemylock = true;
            playerData.currentEnemyPosition = CurrentClosetEnemy.transform.position;

            CameraAim.SetActive(true);
            CameraNormal.SetActive(false);
            aiming = true;

            playerData.speed = playerData.aimingSpeed;
        }

    }

    // Cancels aim 
    private void CancelAim()
    {
        if (aiming)
        {
            CameraNormal.SetActive(true);

            // Recenter Camera
            CameraNormal.GetComponent<CinemachineFreeLook>().m_XAxis.Value = player.transform.rotation.eulerAngles.y;
            CameraNormal.GetComponent<CinemachineFreeLook>().m_YAxis.Value = 0.5f;

            CameraAim.SetActive(false);
            CameraAim2.SetActive(false);
            aiming = false;
            StartCoroutine(EnemyLockFalse());

            playerData.speed = playerData.normalSpeed;
        }
    }

    // BUG Makes possible to aim at invalid enemies for half a second
    IEnumerator EnemyLockFalse()
    {
        yield return new WaitForSeconds(0.5f);
        if (aiming == false)
            playerData.enemylock = false;
    }

    private void CheckForEnemy()
    {
        // Needs to be worked
        // Switch Enemy if its Dead or if it is out of range
        if (_currentTarget != null)
        {
            if (_currentTarget.transform.GetComponent<Enemy>().isDead == true || (_currentTarget.transform.position - player.transform.position).magnitude >= playerData.shootDist)
            {
                SwitchEnemy();
            }
            
        }
    }
}
