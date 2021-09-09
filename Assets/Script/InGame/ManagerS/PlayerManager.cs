using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private SceneManagerScript SceneManagerScript;
    [SerializeField] private SkilManager SkilManager;

    [Header("味方本陣のHP")]
    [SerializeField] private int PlayerHomeHP = 100;
    [Header("味方のMPMax量")]
    [SerializeField] private int MpMax = 100;
    [Header("味方のMP回復量(秒)")]
    [SerializeField] private int MpHeal = 10;
    private int MP;
    private float MPTimer;

   

    private float Timer = 0f;

    void Start()
    {
        if (!SkilManager) { GameObject.Find("SkilManager").GetComponent<SkilManager>(); }
        SceneManagerScript = SceneManagerScript.Instance;
       

        Timer = 0f;
        MP = MpMax;
        MPTimer = 0f;
    }

    void Update()
    {
        //時間計測
        Timer += Time.deltaTime;
        MPTimer += Time.deltaTime;

        if (MPTimer > 1)
        {
            MPTimer = 0f;
            MP += MpHeal;
            if (MP > MpMax) MP = MpMax;
            GameObject MPGauge = GameObject.Find("MPGauge");//MPゲージの取得
            MPGauge.GetComponent<PlayerMP>().UsingMP(MP, MpMax);

            Debug.Log("MP = " + MP);
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1)) SkilOn(1, 0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SkilOn(2, 0);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SkilOn(3, 0);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SkilOn(4, 0);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SkilOn(5, 0);
#endif
    }

    public void OnCollisionEnter(Collision other)
    {
        //弾に当たった
        if (other.gameObject.tag == "Bullet")
        {
            PlayerHomeHP--;
        }
        //モブに当たった
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("aaa");
            PlayerHomeHP -= 1;
        }
        //敗北処理
        if (PlayerHomeHP < 1)
        {
            Debug.Log("まけちゃった");
            SceneManagerScript.LoadRisult();
        }
    }

    //スキル発動処理
    private int MPCost = 0;
    public void SkilOn(int i,int x)
    {
        switch (i){

            case 0:
                var MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_1();
                    MP -= 20;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            case 1:
                MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_1();
                    MP -= 20;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            case 2:
                MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_2();
                    MP -= 20;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            case 3:
                MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_3();
                    MP -= 20;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            case 4:
                MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_4(x);
                    MP -= 20;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            case 5:
                MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_5(x);
                    MP -= 20;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            default: break;
        }

        GameObject MPGauge = GameObject.Find("MPGauge");//MPゲージの取得
        MPGauge.GetComponent<PlayerMP>().UsingMP(MP, MpMax);

        Debug.Log("MP = " + MP);
    }

   
}
