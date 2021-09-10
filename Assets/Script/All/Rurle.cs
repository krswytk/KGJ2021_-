using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rurle : MonoBehaviour
{

    public Image image;
    private Sprite sprite;

    public int imageN;

    // Start is called before the first frame update
    void Start()
    {
        imageN = 1;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        sprite = Resources.Load<Sprite>("Rule"+imageN);
        image = this.GetComponent<Image>();
        image.sprite = sprite;
    }


    public void PushRule()
    {
        this.gameObject.SetActive(true);
    }

    public void PushX()
    {
        this.gameObject.SetActive(false);
    }

    public void PushNext()
    {

        if (imageN==6)
        {
            imageN=1;
        }
        else
        {
            imageN++;
        }
        Debug.Log(imageN);

    }






}
