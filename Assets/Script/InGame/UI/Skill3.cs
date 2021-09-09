using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    SkillButton SkillButton;
    void Start()
    {
        if (!SkillButton) SkillButton = GameObject.Find("Canvas").GetComponent<SkillButton>();

    }
    public void Click()
    {
        SkillButton.Skill3();
    }
}
