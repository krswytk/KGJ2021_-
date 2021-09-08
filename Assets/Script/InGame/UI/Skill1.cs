using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    SkillButton SkillButton;
    void Start()
    {
        if (!SkillButton) SkillButton = GameObject.Find("Canvas").GetComponent<SkillButton>();
    }
    public void Click()
    {
        SkillButton.Skill1();
    }
}
