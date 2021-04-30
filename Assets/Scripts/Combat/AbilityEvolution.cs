using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityEvolution : MonoBehaviour
{
    public PlayerAbilities mainAbility;
    public PlayerAbilities burstAbility;
    public Image displayIcon;
    public GameObject UiAbilityEvolution;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        // Reset Ability levels for now (Remove this Later)
        mainAbility.xp = 0;
        mainAbility.level = 0;
        burstAbility.xp = 0;
        burstAbility.level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Main Ability
        if (mainAbility.xp == 10 && mainAbility.level != 1)
        {
            mainAbility.level = 1;
            displayIcon.sprite = mainAbility.icon;
            StartCoroutine(DispalayEvolution(mainAbility.level));
        }
        if (mainAbility.xp == 20 && mainAbility.level != 2)
        {
            mainAbility.level = 2;
            displayIcon.sprite = mainAbility.icon;
            StartCoroutine(DispalayEvolution(mainAbility.level));
        }

        if (burstAbility.xp == 3 && burstAbility.level != 1)
        {
            burstAbility.level = 1;
            burstAbility.cooldowTime = 10;
            //burstAbility.damage = 10;
            displayIcon.sprite = burstAbility.icon;
            StartCoroutine(DispalayEvolution(burstAbility.level));
        }
    }

    IEnumerator DispalayEvolution(int level)
    {

        text.text = "LEVEL " + level + " -> " + (level + 1).ToString();
        UiAbilityEvolution.gameObject.GetComponent<Animator>().SetBool("Display", true);

        yield return new WaitForSeconds(3);
        UiAbilityEvolution.gameObject.GetComponent<Animator>().SetBool("Display", false);
    }
}
