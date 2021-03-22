using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour
{
    public Player playerData;

    private bool timedSlowed = false;
    private bool canSlowTime = true;
    public Slider timeBar;
    // Start is called before the first frame update
    void Start()
    {
        playerData.playerControls.Gameplay.SlowTime.performed += ctx => SlowTime();
    }

    private void SlowTime()
    {

        if (canSlowTime)
        {
            Time.timeScale = 0.1f;
            timedSlowed = true;
            canSlowTime = false;
            StartCoroutine(SlowTimeUse());
        }
    }

    private IEnumerator SlowTimeUse()
    {
        // Displays Cooldown time for ability 1.
        float duration = 2;
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            remainingTime -= Time.unscaledDeltaTime;
            if (timedSlowed)
                timeBar.value = remainingTime / 2;
            else
                break;
            yield return null;
        }

        Time.timeScale = 1;
        timedSlowed = false;


        StartCoroutine(SlowTimeRecharge());
    }
    private IEnumerator SlowTimeRecharge()
    {
        // Displays Cooldown time for ability 1.
        float duration = 10;
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            remainingTime -= Time.unscaledDeltaTime;
            if (!timedSlowed)
                timeBar.value = (10 - remainingTime) / 10;
            else
                break;
            yield return null;
        }
        canSlowTime = true;
    }
}
