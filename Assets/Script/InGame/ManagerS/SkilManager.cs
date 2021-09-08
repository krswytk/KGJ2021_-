using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilManager : MonoBehaviour
{
    [SerializeField] private GameObject Army1;
    [SerializeField] private GameObject Army2;
    [SerializeField] private GameObject Army3;
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Magic;
    [SerializeField] private float MagicTime = 10;

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
    }


    public void Skill_1()
    {

        Instantiate(Army1, this.transform);
    }
    public void Skill_2()
    {

        Instantiate(Army2, this.transform);
    }
    public void Skill_3()
    {

        Instantiate(Army3, this.transform);
    }
    public void Skill_4(float x)
    {
        Instantiate(Wall, new Vector2(x, -2), Quaternion.identity, this.transform);
    }
    public void Skill_5(float x)
    {
        //�ᐶ��
        var g = Instantiate(Magic,new Vector2(x,1), Quaternion.identity,this.transform);
        //�R���[�`���X�^�[�g
        StartCoroutine(DestroyThis(MagicTime, g));
    }

    private IEnumerator DestroyThis(float time,GameObject Gameobj)
    {
        //��~
        yield return new WaitForSeconds(time);
        //�폜
        Destroy(Gameobj);
    }
}