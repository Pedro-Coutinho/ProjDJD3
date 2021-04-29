using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityEvolution : MonoBehaviour
{
    public PlayerAbilities mainAbility;
    public GameObject UiAbilityEvolution;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        // Reset Ability levels for now (Remove this Later)
        mainAbility.xp = 0;
        mainAbility.level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Main Ability
        if (mainAbility.xp == 10 && mainAbility.level != 1)
        {
            mainAbility.level = 1;
            StartCoroutine(DispalayEvolution());
        }
        if (mainAbility.xp == 20 && mainAbility.level != 2)
        {
            mainAbility.level = 2;
            StartCoroutine(DispalayEvolution());
        }
    }

    IEnumerator DispalayEvolution()
    {

        text.text = "LEVEL " + mainAbility.level + " -> " + (mainAbility.level + 1).ToString();
        UiAbilityEvolution.gameObject.GetComponent<Animator>().SetBool("Display", true);

        yield return new WaitForSeconds(3);
        UiAbilityEvolution.gameObject.GetComponent<Animator>().SetBool("Display", false);
    }
}
