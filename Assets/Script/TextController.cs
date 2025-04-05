using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textComponent;
    public float i = 0;
    public float j = 0;
    public float m = 0;
    float chatFlg1, chatFlg2, chatFlg3,chatFlg4,chatFlg5,chatFlg6,chatFlg7,chatFlg8,chatFlg9,chatFlg10,chatFlg11, chatFlg12 = 0;//フラグに０を入れる
    public int PaperFlg = 0;
    GameObject yes, no;
    public GameObject paper;
    public GameObject wall;

   
     
    
    private void Start()
    {

        // 初期のテキストを設定
        SetText("ん？あれは");

        paper = GameObject.Find("Sphere");
        paper.SetActive(false);

        this.wall = GameObject.Find("WallCollider (13)");
        wall.SetActive(false);
    }

    private void Update()
    {
        i += Time.deltaTime;


        if(i > 3f)
        {
            chatFlg1 = 1;
        }

        if(i > 6f)
        {
            chatFlg2 = 1;
        }

        if(i > 8f)
        {
            chatFlg3 = 1;
        }
        if(i > 12f)
        {
            chatFlg4 = 1;
        }
        if (i > 15f)
        {
            chatFlg5 = 1;
        }
        if (i > 19f)
        {
            chatFlg6 = 1;
        }
        if (i > 24f)
        {
            chatFlg7 = 1;
        }
        if(i > 26f) 
        {
            chatFlg8 = 1;
        }
        if(i > 28f)
        {
            chatFlg9 = 1;
        }
        if( i > 30f)
        {
            chatFlg10 = 1;
        }if(i > 35f)
        {
            chatFlg11 = 1;
        }
        if(i > 37f)
        {
            chatFlg12 = 1;
            wall.SetActive(true);
        }




        if (chatFlg1 == 1 && chatFlg2 == 0 )
        {
            SetText("パパとママじゃないか");
        }
        else if (chatFlg2 == 1 && chatFlg3 == 0 )
        {
            SetText("よう！久しぶりだな");
        }
        else if (chatFlg3 == 1 && chatFlg4 == 0 )
        {
            SetText("まあ！家族写真なんてみたの何十年ぶりかしら");
        } else if (chatFlg4 == 1 && chatFlg5 == 0 )
        {
            SetText("最後にお前に会えてよかったよ。");
        } else if (chatFlg5 == 1 && chatFlg6 == 0 )
        {
            SetText("そうね。これで最後なのよね...");
        }
        else if (chatFlg6 == 1 && chatFlg7 == 0 )
        {
            SetText("最後ってどういうことだよ？");
        }else if(chatFlg7 ==1 && chatFlg8 == 0 )
        {
            SetText("パパのズボンから何か落ちて自分の足元に。");

            PaperFlg = 1;

        }
        else if (chatFlg8 == 1 && chatFlg9 == 0 )
        {
            SetText("おっと！これはまずい！");
           
        } 
        else if (chatFlg9 == 1  && chatFlg10 == 0 )
        {
            SetText("くしゃくしゃになった新聞だ");
           

        }
        else if (chatFlg10 == 1 && chatFlg11 == 0)
        {
            SetText("新聞には両親が事故で亡くなった記事だった");

        }
        else if (chatFlg11 == 1 && chatFlg12 == 0)
        {
            SetText("信じてくれ　わしたちは死んでないんだ");

        }
        else if (chatFlg12 == 1 )
        {
            SetText("信じますか？");
            m += Time.deltaTime;
            if(m > 2f)
            {
                textComponent.gameObject.SetActive(false);
            }
          
        }
        //新聞が落ちて主人公は両親が死んだ新聞を読み　信じてくれわしたちは死んでないんだ　はい　いいえ　で信じるかどうかをきめて
        //信じればわしたちはいつだってずっと家族だ。と言い天に召される
        //信じなければ　婆さんが爺さんやっておしまい！　　怒って爺さんが襲い掛かって来る　１分間攻撃を受けなければ　入口の扉が開いて脱出成功　


        if (PaperFlg == 1)
        {
            paper.SetActive(true);
            Shoot(new Vector3(0, 0,-2));
            j += Time.deltaTime;
            if(j >= 5f)
            {
                paper.SetActive(false);
            }
        }

    }

    void SetText(string newText)
    {
        // Textコンポーネントのtextプロパティを使用してテキストを変更
        textComponent.text = newText;
    }
  
    public void Shoot(Vector3 dir)
    {
       
            paper.GetComponent<Rigidbody>().AddForce(dir);
        
    }
}