using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backMove : MonoBehaviour {

    private Text text;
    private Text text2;
    private Text text3;
    private SpriteRenderer serihu_f;
    private SpriteRenderer jpman;
    private SpriteRenderer serihu_a;
    private SpriteRenderer serihu_a2;
    private Transform back1, back2, back3;  //StageMove
    private Transform araisan;

    private float speed = -0.1f;
    private float rotespeed = -9f;    //0.1f * 90(角度)
    private float time = 0;
    private float araiZ = 0;
    private float scale_max = 5f;
    private float arai_soku = 0;
    private float arai_yoi = 0;
    private float arai_kui = 361;
    private float yoi = 10;
    private bool moveSwich = false;

    // Use this for initialization
	void Start () {
        back1 = GameObject.Find("back1").GetComponent<Transform>();  //StageMove
        back2 = GameObject.Find("back2").GetComponent<Transform>();  //StageMove
        back3 = GameObject.Find("back3").GetComponent<Transform>();  //StageMove
        araisan = GameObject.Find("arai_atama").GetComponent<Transform>();
        araiZ = araisan.rotation.z;
        serihu_f = GameObject.Find("serihu").GetComponent<SpriteRenderer>();
        serihu_a = GameObject.Find("arai_serihu3").GetComponent<SpriteRenderer>();
        serihu_a2 = GameObject.Find("arai_serihu4").GetComponent<SpriteRenderer>();
        jpman = GameObject.Find("jpman_red").GetComponent<SpriteRenderer>();
        text = GameObject.Find("speed").GetComponent<Text>();
        text2 = GameObject.Find("speed2").GetComponent<Text>();
        text3 = GameObject.Find("speed3").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update () {
        
        if (2f < arai_soku && arai_soku < 3.5f)
        {
            arai_yoi += Time.deltaTime * yoi;
        }
        else if (3.5f < arai_soku && arai_soku < 5f)
        {
            arai_yoi += Time.deltaTime * 2 * yoi;
        }
        else if (5f < arai_soku)
        {
            arai_yoi += Time.deltaTime * 3 *yoi;
        }
        


        //入力
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotespeed += 0.5f;
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotespeed -= 0.5f;
            if (back1.position.x > 0)
            {
                moveSwich = true;
            }
        }
        
        //背景進む
        if (moveSwich == true)
        {
            back1.Translate(speed, 0, 0);  //StageMove
            back2.Translate(speed, 0, 0);  //StageMove
            back3.Translate(speed, 0, 0);  //StageMove
        }
        else
        {
            time += Time.deltaTime;
        }
        
        //回転
        if(back1.position.x <= 0 && time < 10)
        {
            araisan.Rotate(0, 0, rotespeed);
            arai_soku = Mathf.Abs(-rotespeed + 9) / 10;
            text.text = "AraiSpeed：" + arai_soku.ToString("N2") + " Fen";
            rotespeed -= 0.1f;
            arai_kui -= (10 - arai_soku) * Time.deltaTime;
            arai_yoi -= Time.deltaTime * yoi / 2;
        }
        else if(back1.position.x <= 0 && (-0.1 + araiZ >= araisan.rotation.z || araisan.rotation.z >= 0.1 + araiZ || back3.position.x > -1))
        {
            if (arai_yoi / 1.5f <= 100)
            {
                moveSwich = true;
                arai_kui -= (10 - arai_soku) * Time.deltaTime;
                arai_yoi -= Time.deltaTime * yoi / 2;
                araisan.Rotate(0, 0, rotespeed);
                arai_soku = Mathf.Abs(-rotespeed + 9) / 10;
                text.text = "AraiSpeed：" + arai_soku.ToString("N2") + " Fen";

            }
            else
            {
                araisan.Rotate(0, 0, rotespeed / 10);
                rotespeed += 0.5f;
                arai_soku = Mathf.Abs(-rotespeed + 9) / 10;
                text.text = "AraiSpeed：" + arai_soku.ToString("N2") + " Fen";
            }
        }
        else if(back1.position.x <= 0)
        {
            serihu_f.enabled = true;
            jpman.enabled = true;
            
            arai_soku = 0;
            text.text = "AraiSpeed：0 Fen";
            serihu_a2.enabled = true;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("Main");
            }
            

        }


        //スピードが上がり過ぎた処理
        if (Mathf.Abs(rotespeed) > 100 && araisan.localScale.x <= scale_max)
        {
            araisan.localScale = new Vector2(araisan.localScale.x + scale_max / 120, araisan.localScale.y + scale_max / 120);
        }

        
        
        text3.text = "AraiFood：" + arai_kui.ToString("N1") + " Fen";

        if (arai_yoi < 0)
        {
            arai_yoi = 0;
        }

        //GameOver
        if (arai_yoi / 1.5 >= 100)
        {
            serihu_f.enabled = true;
            jpman.enabled = true;
            moveSwich = false;
            serihu_a.enabled = true;
            arai_soku = 0;
            time = 10;
            text.text = "AraiSpeed：0 Fen";
            text2.text = "Bad Feel：100 %";
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("Main");
            }
        }
        else
        {
            
            text2.text = "Bad Feel：" + (arai_yoi * 2 / 3).ToString("N1") + " %";
        }
    }

    public void Swich()
    {
        if (moveSwich == true)
        {
            moveSwich = false;
        }
        else
        {
            moveSwich = true;
        }
    }
}
