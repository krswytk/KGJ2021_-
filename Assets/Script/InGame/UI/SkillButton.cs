using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private PlayerManager PlayerManager;

    [SerializeField] private GameObject WallAreaImage;
    private bool WallSw = false;
    [SerializeField] private GameObject HealAreaImage;
    private bool HealSw = false;

    private void Start()
    {
        if(!PlayerManager) PlayerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        if (!WallAreaImage) WallAreaImage = GameObject.Find("WallAreaImage");
        if (!HealAreaImage) HealAreaImage = GameObject.Find("HealAreaImage");
    }

    public void Skill1()
    {
        PlayerManager.SkilOn(1, 0);
    }
    public void Skill2()
    {
        PlayerManager.SkilOn(1, 0);
    }
    public void Skill3()
    {
        PlayerManager.SkilOn(1, 0);
    }
    public void Skill4()
    {
        if (!WallSw)
        {
            WallSw = true;
            WallAreaImage.SetActive(true);
        }
        else
        {
            WallSw = false;
            WallAreaImage.SetActive(false);
        }
        PlayerManager.SkilOn(1, 0);
    }
    public void Skill5()
    {
        PlayerManager.SkilOn(1, 0);
    }

}
