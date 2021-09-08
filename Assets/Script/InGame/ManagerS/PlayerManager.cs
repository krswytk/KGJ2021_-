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

    private float Timer = 0f;

    void Start()
    {
        if (!SkilManager) { GameObject.Find("SkilManager").GetComponent<SkilManager>(); }
        SceneManagerScript = SceneManagerScript.Instance;

        Timer = 0f;
        MP = MpMax;
        //MPの回復
        StartCoroutine(MPHeal());
    }

    void Update()
    {
        //時間計測
        Timer += Time.deltaTime;
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1)) SkilOn(1, 0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SkilOn(2, 0);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SkilOn(3, 0);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SkilOn(4, 0);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SkilOn(5, 0);
#endif
    }

    public void OnTriggerEnter(Collider other)
    {
        //弾に当たった
        if (other.tag == "Bullet")
        {
            PlayerHomeHP--;
        }
        //モブに当たった
        if (other.tag == "Enemy")
        {
            PlayerHomeHP -= 5;
        }

        //敗北処理
        if (PlayerHomeHP < 1)
        {
            Debug.Log("まけちゃった");
            SceneManagerScript.LoadRisult();
        }
    }

    //スキル発動処理
    public void SkilOn(int i,int x)
    {
        switch (i){

            case 0: SkilManager.Skill_1(); MP -= 20; break;

            case 1: SkilManager.Skill_1(); MP -= 20; break;

            case 2: SkilManager.Skill_2(); MP -= 20; break;

            case 3: SkilManager.Skill_3(); MP -= 20; break;

            case 4: SkilManager.Skill_4(x); MP -= 20; break;

            case 5: SkilManager.Skill_5(x); MP -= 20; break;

            default: break;
        }
        Debug.Log("MP = " + MP);
    }

    private IEnumerator MPHeal()
    {
        yield return new WaitForSeconds(1);

        MP += MpHeal;
        if (MP > MpMax) MP = MpMax;

        yield return null;
    }
}
