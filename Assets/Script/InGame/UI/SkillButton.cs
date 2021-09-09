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
        #region URL
        //https://techblog.gracetory.co.jp/entry/2018/06/04/000000#%E3%82%BF%E3%83%83%E3%83%81%E3%81%97%E3%81%9F%E7%AE%87%E6%89%80%E3%81%AB%E3%82%BF%E3%83%83%E3%83%81%E5%AF%BE%E8%B1%A1%E3%81%8C%E3%81%84%E3%82%8B%E3%81%8B%E8%AA%BF%E3%81%B9%E3%82%8B
        #endregion
        TouchManager.update();
        // �^�b�`�擾
        var touch_state = TouchManager.getTouch();
        // �^�b�`����Ă����珈��
        if (touch_state._touch_flag)
        {
            // ���W�n�ϊ�
            Vector2 world_point = Camera.main.ScreenToWorldPoint(touch_state._touch_position);

            if (touch_state._touch_phase == TouchPhase.Began)
            {
                // �^�b�`�����u�Ԃ̏���
                RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);
                // �`�b�v�؂�ւ�
                if (hit)
                {
                    Debug.Log("�I�u�W�F�N�g�Ƀ^�b�`������");
                    // �^�b�`���̏������s��
                    Debug.Log(hit.collider.gameObject.name);
                }
                else
                {
                    Debug.Log("�����ɃI�u�W�F�N�g�͖�����");
                }
            }//��Ƀ}�E�X�̍��W���L�^�AON���ɃN���b�N�����m������A�A�I�u�W�F�N�g�ɂ����ԂăC���J���f���ׁA�ANO

        }
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
