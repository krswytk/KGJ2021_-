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
    [SerializeField] PlayerMP PlayerMP;

    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;


    private float Timer = 0f;

    void Start()
    {
        if (!SkilManager) { GameObject.Find("SkilManager").GetComponent<SkilManager>(); }
        SceneManagerScript = SceneManagerScript.Instance;


        if (!PlayerMP) { GameObject.Find("MPGauge").GetComponent<PlayerMP>(); }

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
            PlayerMP.UsingMP(MP, MpMax);//MPゲージに反映

            //Debug.Log("MP = " + MP);
        }

        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

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

            Lisult.GameSet = false;
            
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
                MPCost = SkilManager.MPCostCheck(MP, 0);
                if (MPCost != -1)
                {
                    SkilManager.Skill_1();
                    MP -= MPCost;
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
                    MP -= MPCost;
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
                    MP -= MPCost;
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
                    MP -= MPCost;
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
                    SkilManager.Skill_4(screenToWorldPointPosition.x);
                    MP -= MPCost;
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
                    SkilManager.Skill_5(screenToWorldPointPosition.x);
                    MP -= MPCost;
                }
                else
                {
                    Debug.Log("魔力が足りないよ！");
                }
                break;

            default: break;
        }

        PlayerMP.UsingMP(MP, MpMax);//MPゲージに反映

        //Debug.Log("MP = " + MP);
    }

   
}
