using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private PlayerManager PlayerManager;

    [SerializeField] private GameObject WallAreaImage;
    private bool WallSw = false;
    [SerializeField] private GameObject HealAreaImage;
    private bool HealSw = false;

    private TouchManager TouchManager;

    private void Start()
    {
        if(!PlayerManager) PlayerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        if (!WallAreaImage) WallAreaImage = GameObject.Find("WallAreaImage");
        if (!HealAreaImage) HealAreaImage = GameObject.Find("HealAreaImage");
        WallAreaImage.SetActive(false);
        HealAreaImage.SetActive(false);

        TouchManager = new TouchManager();
    }
    private void Update()
    {
       
    }

    public void Skill1()
    {
        PlayerManager.SkilOn(1, 0);
    }
    public void Skill2()
    {
        PlayerManager.SkilOn(2, 0);
    }
    public void Skill3()
    {
        PlayerManager.SkilOn(3, 0);
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
    }
    public void Skill4Select()
    {
        PlayerManager.SkilOn(4, 0);
        Skill4();
    }
    public void Skill5()
    {
        if (!HealSw)
        {
            HealSw = true;
            HealAreaImage.SetActive(true);
        }
        else
        {
            HealSw = false;
            HealAreaImage.SetActive(false);
        }
    }

    public void Skill5Select()
    {
        PlayerManager.SkilOn(5, 0);
        Skill5();
    }
}
