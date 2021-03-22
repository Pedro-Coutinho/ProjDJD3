using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.InputSystem;

public class UiHealth : MonoBehaviour
{
    public PlayerStats playerstats;
    public TextMeshProUGUI healthText;
    public CinemachineFreeLook ThirdPersonCam;
    public CinemachineVirtualCamera AimCam1;
    public CinemachineVirtualCamera AimCam2;

    private Slider healthBar;

    private bool hit = false;
    private float currentHealth;

    private void Start()
    {
        ThirdPersonCam = ThirdPersonCam.GetComponent<CinemachineFreeLook>();
        playerstats.currentHeath = playerstats.playerHealth;
        currentHealth = playerstats.currentHeath;
        healthBar = gameObject.transform.GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerstats.currentHeath != currentHealth)
        {
            hit = true;
        }

        if (playerstats.currentHeath < 0)
        {
            playerstats.currentHeath = 0;
        }

        if (hit)
        {
            healthText.text = playerstats.currentHeath + "/10";
            healthBar.value = 1 - (playerstats.playerHealth - playerstats.currentHeath) / playerstats.playerHealth;

            StartCoroutine(ShakeCam());
            Gamepad.current.SetMotorSpeeds(0.3f, 0.2f);
            currentHealth = playerstats.currentHeath;
            hit = false;
        }
        
    }

    // CamShake damage
    IEnumerator ShakeCam()
    {
        
        float duration = 0.5f;
        float remainingTime = duration;
        
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            ThirdPersonCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = remainingTime * 6;
            ThirdPersonCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = remainingTime * 6;
            ThirdPersonCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = remainingTime * 6;
            AimCam1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = remainingTime * 6;
            AimCam2.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = remainingTime * 6;
            yield return null;
        }
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
}
