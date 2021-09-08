using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private SceneManagerScript SceneManagerScript;
    [SerializeField] private SkilManager SkilManager;

    [Header("–¡•û–{w‚ÌHP")]
    [SerializeField] private int PlayerHomeHP = 100;
    [Header("–¡•û‚ÌMPMax—Ê")]
    [SerializeField] private int MpMax = 100;
    [Header("–¡•û‚ÌMP‰ñ•œ—Ê(•b)")]
    [SerializeField] private int MpHeal = 10;
    private int MP;

    private float Timer = 0f;

    void Start()
    {
        if (!SkilManager) { GameObject.Find("SkilManager").GetComponent<SkilManager>(); }
        SceneManagerScript = SceneManagerScript.Instance;

        Timer = 0f;
        MP = MpMax;
        //MP‚Ì‰ñ•œ
        StartCoroutine(MPHeal());
    }

    void Update()
    {
        //ŠÔŒv‘ª
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
        //’e‚É“–‚½‚Á‚½
        if (other.tag == "Bullet")
        {
            PlayerHomeHP--;
        }
        //ƒ‚ƒu‚É“–‚½‚Á‚½
        if (other.tag == "Enemy")
        {
            PlayerHomeHP -= 5;
        }

        //”s–kˆ—
        if (PlayerHomeHP < 1)
        {
            Debug.Log("‚Ü‚¯‚¿‚á‚Á‚½");
            SceneManagerScript.LoadRisult();
        }
    }

    //ƒXƒLƒ‹”­“®ˆ—
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
