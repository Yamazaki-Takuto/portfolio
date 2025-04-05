using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityFx.Outline;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;
//using System.Runtime.Remoting.Messaging;


public class Person_Controller : MonoBehaviour
{
  
    public static Person_Controller instance;
    float inputVertical;//WとSの上下入力を入れる
    private float currentXRotation = 0f; // 現在の上下の角度
    private float rotationLimit = 60f; // 上下の回転制限（度）
    private GameObject imageUi;//UIのImage
    private GameObject HintUI;//ヒントのImage
    private GameObject text1, text2, text3, text4, text5, text6, text7;
    private Image itemImage,GameImage;//コンポーネントのImageを入れる変数
    public Sprite RentiSprite, NozzleSprite, VacuumCleanerSprite, fireExtinguisherSprite, PressureCleanerSprite,HeitaicSprite,HintSprite,nothingSprite, photoSprite;//画像を入れるところ


    //ゲームオブジェクトを実体化
    private GameObject WaterLeak;//キッチンの水の情報を入れる
    public GameObject renti;  //レンチの情報を入れる変数
    private GameObject Fire;  //消火器の情報を入れる変数
    private GameObject kitchen;//キッチンの水場
    private GameObject hikidasi;//ほうきが入ってる引き出し
            GameObject tyusin;//消火器の中心座標の変数（エンプティ）
    private GameObject nozzle;//掃除機ノズル
    private float nozzleFlg = 0;  //ノズルを入手したかのフラグ
    private GameObject handle;//掃除機ハンドル
    private float HandiFlg = 0;//ハンディー掃除機が持っているかどうか
    private GameObject LoCube;//LOの書かれたキューブ
    private GameObject youCube;//youの書かれたキューブ
    private GameObject ICube;//Iと書かれたキューブ
    private float LoFlg = 0;
    private float IFlg = 0;
    private float hokori_cnt = 10f;//ホコリほんとは10f
    private GameObject sofa1, sofa2, sofa3;//ソファーのホコリ
    private GameObject sphere1, sphere2, sphere3, sphere4, sphere5;
    private GameObject fire1, fire2, fire3;//消火器のホコリ
    public GameObject flame;//火
    private GameObject WaterObj;//消火剤
    private GameObject pressureCleaner;//高圧洗浄機
    public int flameFlg = 0;//消火器で火を消せたか
    public int FlameOn = 0;//炎を出現させる
    private int CleanerFlg = 0;//高圧洗浄機を持っているか
    private GameObject CleanerObj;//洗浄機の水

    private GameObject heitai_c;//お風呂場の兵隊C
    private GameObject heitai_kc;//棚の兵隊C
    private GameObject capsule;//兵隊Cを置くスペース
    float heitaicFlg = 0;//兵隊Cを持っているかどうか
    public float YogoreCnt = 12f;//汚れの数
    private GameObject HintPhoto;//ヒントの画像
    private GameObject gameobject;//パスワードのゲームオブジェクト
    private GameObject photo;//写真
    private GameObject chest;//宝箱


    public Text TextComment;//画面上のテキスト
    public Text gameText;//アイテム入手や使うときのテキスト
    public Text gameText2;//アイテムの名称などの補助テキスト
    float j = 0;
    float Startcnt = 0f;
    




    float f = 0;//ヒントの画像を表示する時間を入れる
    float i = 0;
    //GameObject text;//制限時間を呼び出す
    private float startTime;//開始時間
    private int tapCount;//タップした回数
    private float tapSpeedThreshold = 5f;  // 1秒あたりの最低連打回数
    private bool isCrouching = false;  // しゃがみの状態を保持するフラグ


    private bool isHitting = false;
    private float Timer = 0f;//経過時間
    private float destroyTime = 5f; // 10秒で破壊する
    float  HintTimer = 0f;

  

    

    float SyagamiFlg = 0;//今しゃがんでいるかのフラグ

    Rigidbody rb;//重力の情報をを入れる
  public int WaterFrg = 0;//しゃがむとレンチがとれるフラグ
  
    int Firefrg = 0;//消火器を取得した時のフラグ
    int FireCome = 0;//消火器の取得のコメントを優先するため
    int PreCome = 0;
   public int PreFlg = 0;//高圧洗浄機を入手したかのフラグ
   public int tFlg = 0; //テキストの秒数を図るフラグ
    int hntFlg = 0;//ヒントの画像を持っているか
    int photoFlg = 0;
   
    Quaternion q = Quaternion.Euler(34f,-87f,0.02f);//プレイヤーの上下の向ける角度

    


    float moveSpeed = 4f;//移動速度
   
    Vector3 Sensa = new Vector2(Screen.width/2, Screen.height/2);//Rayを飛ばしたりする画面の中心

    //効果音
    public AudioClip ItemClip;//アイテム入手音
    public AudioClip RentiClip;//レンチの音
    public AudioClip WaterClip;//水の音
    public AudioClip VacuumClip;//掃除機の音
    public AudioClip FireClip;//炎の音
    public AudioClip fire_extClip;//消火器の音
    public AudioClip WaterSpClip;//高圧洗浄機の音
    public AudioClip heitaiClip;//兵隊の出現音
    public AudioClip angelClip;//兵隊の並べた時の音
    public AudioSource audioSource;
   
    void Start()
    {
        HideGameText2();
        ShowGameText( "ゲーム開始！");
        this.rb = GetComponent<Rigidbody>();//rigidbodyを取得
       
        this.WaterLeak = GameObject.Find("WaterLeak");//水
        this.renti = GameObject.Find("Renti");//レンチ
        this.Fire = GameObject.Find("fire extinguisher");//消火器
        this.pressureCleaner = GameObject.Find("PressureCleaner");//高圧洗浄機
        this.tyusin = GameObject.Find("F_Tyusin");//消火器の中心座標
        this.hikidasi = GameObject.Find("PFB_ChestOfDraws");//引き出し
        this.kitchen = GameObject.Find("door01");//シンクの下のドア
        this.nozzle = GameObject.Find("Cleaner_Nozzle");//掃除機ノズル
        this.handle = GameObject.Find("Cleaner_Handle");//掃除機ハンドル
        this.LoCube = GameObject.Find("LO_Cube");//LOキューブ
        this.youCube = GameObject.Find("You_Cube");//EOキューブ
        this.ICube = GameObject.Find("I_Cube");//Iキューブ
        this.sofa1 = GameObject.Find("Sofa1");//ソファーのホコリ
        this.sofa2 = GameObject.Find("Sofa2");//ソファーのホコリ
        this.sofa3 = GameObject.Find("Sofa3");//ソファーのホコリ
        this.sphere1 = GameObject.Find("TVH1");
        this.sphere2 = GameObject.Find("TVH2");
        this.sphere3 = GameObject.Find("TVH3");
        this.sphere4 = GameObject.Find("TVH4");
        this.sphere5 = GameObject.Find("TVH5");
        this.fire1 = GameObject.Find("Fire1");
        this.fire2 = GameObject.Find("Fire2");
        this.fire3 = GameObject.Find("Fire3");
        this.flame = GameObject.Find("Flame");
        this.WaterObj = GameObject.Find("GameObject");
        this.CleanerObj = GameObject.Find("GameObject1");
        this.heitai_c = GameObject.Find("Heitai_C");
        this.heitai_kc = GameObject.Find("Heitai_KC");
        this.capsule = GameObject.Find("Capsule");
        this.text1 = GameObject.Find("HeiMasseage");
        this.text2 = GameObject.Find("HeiMasseage2");
        this.text3 = GameObject.Find("HeiMasseage3_A");
        this.text4 = GameObject.Find("HeiMasseage3_B");
        this.text5 = GameObject.Find("HeiMasseage4");
        this.text6 = GameObject.Find("HeiMasseage5_A");
        this.text7 = GameObject.Find("HeiMasseage5_B");
        this.HintPhoto = GameObject.Find("photo");
        this.photo = GameObject.Find("Quad");
        this.gameobject = GameObject.Find("GameObject4");
        this.chest = GameObject.Find("Takarabako");
       
       
        this.imageUi = GameObject.Find("ImageUI");//道具の画像を表示するところ
        this.itemImage = imageUi.GetComponent<Image>();//ImageUIのコンポーネントのImageを入れる
        this.HintUI = GameObject.Find("HintImage");
        this.GameImage = HintUI.GetComponent<Image>();//HintUIのコンポーネントのImageを入れる
        this.GameImage.sprite = HintSprite;

        

        flame.SetActive(false);
        WaterObj.SetActive(false);
        CleanerObj.SetActive(false);
        heitai_c.SetActive(false);
        heitai_kc.SetActive(false);
        HintPhoto.SetActive(false);
        HintUI.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = WaterClip;
        audioSource.loop = true;//ループ再生
        audioSource.Play();


    }
    




    void Update()
    {
       
        Startcnt += Time.deltaTime;
        
        inputVertical = Input.GetAxis("Vertical");//WとSの入力を受け取る

        Fire.GetComponent<OutlineBehaviour>().enabled = false;
        pressureCleaner.GetComponent<OutlineBehaviour>().enabled = false;
        HintPhoto.GetComponent<OutlineBehaviour>().enabled = false;
        photo.GetComponent<OutlineBehaviour>().enabled = false;

      


        Vector3 Renti_Pos = this.renti.transform.position;//レンチの座標
        Vector3 Fire_Pos = this.tyusin.transform.position;//消火器の座標
        Vector3 Nozzle_Pos = this.nozzle.transform.position;//掃除機ノズルの座標
        Vector3 Handle_Pos = this.handle.transform.position;//掃除機ハンドルの座標
        Vector3 Hiki_Pos =this.hikidasi.transform.position;//人形の棚
        Vector3 Kit_Pos = this.kitchen.transform.position;//水の棚
        Vector3 Hoko1_Pos = this.sofa1.transform.position;//ホコリ1
        Vector3 Hoko2_Pos = this.sofa2.transform.position;//ホコリ2
        Vector3 Hoko3_Pos = this.sofa3.transform.position;//ホコリ3
        Vector3 sphere1_Pos = this.sphere1.transform.position;//tv1
        Vector3 sphere2_Pos = this.sphere3.transform.position;//tv3
        Vector3 sphere3_Pos = this.sphere4.transform.position;//tv4
        Vector3 sphere4_Pos = this.sphere5.transform.position;//tv5
        Vector3 Fire1_Pos = this.fire1.transform.position;
        Vector3 Fire2_Pos = this.fire2.transform.position;
        Vector3 Fire3_Pos = this.fire3.transform.position;
        Vector3 capsule_Pos = this.capsule.transform.position;//兵隊のカプセル
        Vector3 Player = transform.position;//プレイヤーの座標
        Vector3 Cleaner = this.pressureCleaner.transform.position;//高圧洗浄機の座標
        Vector3 photo_Pos = this.photo.transform.position;//写真の座標
       
       


        //各アイテムの取得距離

        //レンチの当たり判定の距離
        Vector3 dir = Renti_Pos - Player;
        float d = dir.magnitude;

        //掃除機ノズル当たり判定の距離
        Vector3 atr2 = Nozzle_Pos - Player;
        float n = atr2.magnitude;

        //掃除機ハンドルの当たり判定の距離
        Vector3 atr3 = Handle_Pos - Player;
        float v = atr3.magnitude;
       

        //消火器の当たり判定
        Vector3 atr = Fire_Pos - Player;
        float a = atr.magnitude;
        float b1 = 0.5f;
        float b2 = 1.0f;

        //キッチンの当たり判定の距離
        Vector3 atr1 = Kit_Pos - Player;
        float d1 = atr1.magnitude;

        //引き出しの当たり判定の距離
        Vector3 hik = Hiki_Pos - Player;
        float c = hik.magnitude;

        //Sofa1の当たり距離
        Vector3 atrh1 = Hoko1_Pos - Player;
        float h1 = atrh1.magnitude;

        //Sofa2の当たり距離
        Vector3 atrh2 = Hoko2_Pos - Player;
        float h2 = atrh2.magnitude;

        //Sofa3の当たり距離
        Vector3 atrh3 = Hoko3_Pos - Player;
        float h3 = atrh3.magnitude;

        Vector3 atrt1 = sphere1_Pos - Player;
        float t1 = atrt1.magnitude;

        Vector3 atrt2 = sphere2_Pos - Player;
        float t2 = atrt2.magnitude;

        Vector3 atrt3 = sphere3_Pos - Player;
        float t3 = atrt3.magnitude;

        Vector3 atrt4 = sphere4_Pos - Player;
        float t4 = atrt4.magnitude;

        //Fire1の当たり距離
        Vector3 atrf1 = Fire1_Pos - Player;
        float f1 = atrf1.magnitude;

        //Fire2の当たり距離
        Vector3 atrf2 = Fire2_Pos - Player;
        float f2 = atrf2.magnitude;

        //Fire3の当たり距離
        Vector3 atrf3 = Fire3_Pos - Player;
        float f3 = atrf3.magnitude;

        //Cleaner当たり判定
        Vector3 pre = Cleaner - Player;
        float r = pre.magnitude;
        float c1 = 1.0f;
        float c2 = 1.0f;

        //カプセルの当たり判定
        Vector3 cap = capsule_Pos - Player;
        float c3 = cap.magnitude;

        //写真の当たり判定
        Vector3 Qua = photo_Pos - Player;
        float q = Qua.magnitude;

        Ray ray = Camera.main.ScreenPointToRay(Sensa);//画面の中心にRayを飛ばす

        RaycastHit hit;//Rayが当たった先を取得する変数

        
        


        renti.GetComponent<OutlineBehaviour>().enabled = false;//ある程度近くに来ないとアウトラインを光らせない


        /*if (Timer > 20f)//二十秒経ったらヒントを出す
        {
            Debug.Log("流し場でレンチを使う");
        }*/

        
        
       if(Startcnt > 5f)
        {
           HideGameText();
        }
        
        if(Startcnt > 15f && WaterFrg == 0)
        { 
          ShowGameText2( "テーブルの下にある\nレンチを入手しよう");
           
        }

        if(WaterFrg == 1 && nozzleFlg == 0)
        {
         ShowGameText2("レンチを入手した！これで水が止められる");
        }
            Physics.Raycast(ray, out hit);//Rayを飛ばした先のオブジェクト情報を格納す

        if (hit.collider != null && hit.collider.gameObject != null)
        {
           // Debug.Log("HitObject: " + hit.collider.gameObject.name);
        }

        if (LoFlg == 0)
        {
            LoCube.SetActive(false);//LoCubeを表示
        }
        /* if (Physics.Raycast(ray, out hit))
         {
             //Debug.Log(hit.collider.gameObject.name);
             if (hit.collider.CompareTag("Renti"))//Rayにレンチが当たったらアウトラインを出す
             {
                 renti.GetComponent<OutlineBehaviour>().enabled = true;
             }
             if (hit.collider.CompareTag("Fire"))
             {
                 Fire.GetComponent<OutlineBehaviour>().enabled = true;
             }
             else
             {
                 Fire.GetComponent<OutlineBehaviour>().enabled = false;
             }
             if (hit.collider.CompareTag("Souzi"))
             {
                 soziki.GetComponent<OutlineBehaviour>().enabled = true;
             }
             else
             {
                 soziki.GetComponent<OutlineBehaviour>().enabled = false;
             }




         }*/
        

      

        if (nozzleFlg < 1)//水を止めないと掃除機ノズルを表示しない
        {
            nozzle.SetActive(false);//掃除機ノズルを非表示
        }

        if (d < 3f)//レンチに近づいたら
            {
                renti.GetComponent<OutlineBehaviour>().enabled = true;//青くアウトラインを光らせて
               
               
                if (d < 1f && SyagamiFlg == 1 && hit.collider.CompareTag("Renti"))//レンチの取得
                {
                   ShowGameText("取得する:Nキー");
                    renti.GetComponent<OutlineBehaviour>().OutlineColor = UnityEngine.Color.red;//取得できる距離だからアウトラインを赤くする
                    if (Input.GetKeyDown(KeyCode.N))
                    {
                       
                        itemImage.sprite = RentiSprite;//レンチの画像に差し替えて表示する
                        audioSource.PlayOneShot(ItemClip);
                        renti.SetActive(false);//レンチを非表示にする
                        WaterFrg = 1;//レンチを取得した時のフラグ

                    }
                }
                else
                {
                    renti.GetComponent<OutlineBehaviour>().OutlineColor = UnityEngine.Color.blue;//レンチを取得せずに離れたら青く光る
               
                }
            }

       



         


            if (d1 < 1f && WaterFrg > 0 && WaterFrg == 1)//シンクに近づいている　かつ　レンチを取得していればture
        {

            ShowGameText("レンチをエンター連打で使う");
           


            if (Input.GetKeyDown(KeyCode.Return))//エンターキーを認識　（連打）
            {
                // タップ回数をインクリメント
                tapCount++;

                // 初回のタップなら開始時間を設定
                if (startTime == 0f)
                {
                    startTime = Time.time;//経過した秒数を代入
                }
                else if (WaterFrg < 2)//クリアの速度より遅い場合
                {
                    // 2回目以降のタップなら連打速度を計算して表示
                    float elapsedTime = Time.time - startTime;
                    float tapSpeed = tapCount / elapsedTime; // 1秒あたりのタップ回数を計算
                  //  Debug.Log("Tap Speed: " + tapSpeed.ToString("F2") + " taps per second");


                    // 達成したタップ速度に応じたコメントを表示
                    if (tapSpeed >= tapSpeedThreshold)
                    {
                        //水の音を停止
                        audioSource.Stop();
                        audioSource.PlayOneShot(RentiClip);
                        gameText2.gameObject.SetActive(false);
                        //水を止める音2025.02/18.20:02
                        
                        //Debug.Log("クリア！");
                        nozzle.SetActive(true);//掃除機ノズルを表示
                        nozzleFlg = 1;//ノズルを表示するためのフラグを立てる
                        WaterFrg = 2;//水を止めた時フラグを立てる
                        LoFlg = 1;
                        
                        if (LoFlg == 1)
                        {
                            LoCube.SetActive(true);//LOキューブを表示
                        }




                        // WaterLeakを非表示にする
                        if (WaterLeak != null)
                        {
                            WaterLeak.SetActive(false);//水を非表示
                        }

                    }



                    // タップ情報をリセット
                    startTime = Time.time;
                    tapCount = 0;
                }

            }
        }
       
            if (n < 1f && nozzleFlg == 1)//ノズルに近づいたら
            {
            if (hit.collider.CompareTag("nozzle"))
            {
                ShowGameText("取得する:Nキー");
            }
             
               
            if (hit.collider.CompareTag("nozzle") && Input.GetKeyDown(KeyCode.N))
                {
                    audioSource.PlayOneShot(ItemClip);
                    ShowGameText2("掃除機ノズルを入手した！\n持ち手があれば掃除機が入手できる");
                    itemImage.sprite = NozzleSprite;//ノズルの画像に差し替えて表示
                    nozzle.SetActive(false);
                    nozzleFlg = 2;
                }
            }
            

        

       //今日よること　ヒントのコメントをいれて　できるならクリアシーンの爺の音を入れたりする
        
        

        if (v < 1f && nozzleFlg == 2 && hit.collider.CompareTag("handle"))
        {
            gameText.gameObject.SetActive(true);
            gameText.text = "取得する:Nキー";
            handle.GetComponent<OutlineBehaviour>().enabled = true;
            if (Input.GetKeyDown(KeyCode.N))
            {
                gameText2.text ="ハンディー掃除機を手に入れた！\nエンター長押しでホコリが吸えます";
                audioSource.PlayOneShot(ItemClip);
                audioSource.clip = VacuumClip;
                itemImage.sprite = VacuumCleanerSprite;
                handle.SetActive(false);
                HandiFlg=1;
             
            }
        }
        else
        {
            handle.GetComponent<OutlineBehaviour>().enabled = false;
        }

       // int f = 0;//よごれの数
        // レイを飛ばしてオブジェクトを検出
        if (Physics.Raycast(ray, out hit))
        {
            if (HandiFlg == 1 && heitaicFlg != 1)
            {
                ShowGameText("ホコリを吸う:エンター長押し");
                // レイがSofa1, Sofa2, Sofa3のいずれかにヒットした場合
                if (hit.collider.gameObject.CompareTag("sofa_1") || hit.collider.gameObject.CompareTag("sofa_2") || hit.collider.gameObject.CompareTag("sofa_3") ||
                    hit.collider.gameObject.CompareTag("tv1") || hit.collider.gameObject.CompareTag("tv2") || hit.collider.gameObject.CompareTag("tv3") || hit.collider.gameObject.CompareTag("tv4") ||
                    hit.collider.gameObject.CompareTag("Fire_1") || hit.collider.gameObject.CompareTag("Fire_2") || hit.collider.gameObject.CompareTag("Fire_3"))
                {


                    
               
                    if (Input.GetKey(KeyCode.Return))
                    {
                        if (!audioSource.isPlaying)  // すでに再生されていない場合のみ再生
                        {
                            
                            audioSource.PlayOneShot(VacuumClip);//いい感じ！イメージ通り2025.02/19
                        }

                        if (!isHitting)
                        {
                            isHitting = true;
                            Timer = 0f; // タイマーをリセット
                        }

                        // タイマーを更新
                        Timer += Time.deltaTime;

                        // タイマーが指定の時間を超えた場合
                        if (Timer >= destroyTime)
                        {
                            // これ以上アクセスしないようにする
                            isHitting = false;

                            // Sofa1, Sofa2, Sofa3のオブジェクトを破壊
                            if (HandiFlg > 0 && h1 < 2f && hit.collider.gameObject.CompareTag("sofa_1"))
                            {
                                sofa1.SetActive(false);
                                hokori_cnt--;
                               gameText2.text= "ホコリ残り" + hokori_cnt + "個です";
                            }
                            else if (HandiFlg > 0 && h2 < 2f && hit.collider.gameObject.CompareTag("sofa_2"))
                            {
                                sofa2.SetActive(false);
                                hokori_cnt--;
                                gameText2.text = "ホコリ残り" + hokori_cnt + "個です";
                            }
                            else if (HandiFlg > 0 && h3 < 2f && hit.collider.gameObject.CompareTag("sofa_3"))
                            {
                                sofa3.SetActive(false);
                                hokori_cnt--;
                                gameText2.text = "ホコリ残り" + hokori_cnt + "個です";
                            }
                            else if (HandiFlg > 0 && t1 < 2f && hit.collider.gameObject.CompareTag("tv1"))// tv1, tv2, tv3,tv4,tv5のオブジェクトを破壊
                            {
                                sphere1.SetActive(false);
                                sphere2.SetActive(false);
                                hokori_cnt--;
                             //   SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                            else if (HandiFlg > 0 && t2 < 2f && hit.collider.gameObject.CompareTag("tv2"))
                            {
                                sphere3.SetActive(false);
                                hokori_cnt--;
                             //   SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                            else if (HandiFlg > 0 && t3 < 2f && hit.collider.gameObject.CompareTag("tv3"))
                            {
                                sphere4.SetActive(false);
                                hokori_cnt--;
                             //   SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                            else if (HandiFlg > 0 && t4 < 2f && hit.collider.gameObject.CompareTag("tv4"))
                            {
                                sphere5.SetActive(false);
                                hokori_cnt--;
                             //   SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                            else if (HandiFlg > 0 && f1 < 1f && hit.collider.gameObject.CompareTag("Fire_1"))
                            {
                                fire1.SetActive(false);
                                hokori_cnt--;
                              //  SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                            else if (HandiFlg > 0 && f2 < 1f && hit.collider.gameObject.CompareTag("Fire_2"))
                            {
                                fire2.SetActive(false);
                                hokori_cnt--;
                            //    SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                            else if (HandiFlg > 0 && f3 < 1f && hit.collider.gameObject.CompareTag("Fire_3"))
                            {
                                fire3.SetActive(false);
                                hokori_cnt--;
                              //  SetText2("ホコリ残り" + hokori_cnt + "個です");
                            }
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.Return))  // キーを離したら止める
                    {
                        audioSource.Stop();
                    }
                }
            }
            
            /*else if(hit.collider.gameObject.CompareTag("Yogore0") || hit.collider.gameObject.CompareTag("Yogore1") || hit.collider.gameObject.CompareTag("Yogore2") ||
                hit.collider.gameObject.CompareTag("Yogore3") || hit.collider.gameObject.CompareTag("Yogore4") || hit.collider.gameObject.CompareTag("Yogore5") ||
                hit.collider.gameObject.CompareTag("Yogore6")|| hit.collider.gameObject.CompareTag("Yogore7") || hit.collider.gameObject.CompareTag("Yogore8") ||
                hit.collider.gameObject.CompareTag("Yogore9") || hit.collider.gameObject.CompareTag("Yogore10") || hit.collider.gameObject.CompareTag("Yogore11") ||
                hit.collider.gameObject.CompareTag("Yogore12") || hit.collider.gameObject.CompareTag("Yogore13") || hit.collider.gameObject.CompareTag("Yogore14") ||
                hit.collider.gameObject.CompareTag("Yogore15"))
            {
                if (CleanerFlg == 1 && y0 < 2f && hit.collider.gameObject.CompareTag("Yogore0"){
                    quad0.SetActive(false);
                    f++;
                    Debug.Log("よごれが" + f + "消えたよ");
                }
                else if (CleanerFlg == 1 && y1 < 2f && hit.collider.gameObject.CompareTag("Yogore1"){
                    quad0.SetActive(false);
                    f++;
                    Debug.Log("よごれが" + f + "消えたよ");
                }
            }
           */
                
                    
                

            
        }
        else
        {
            // レイが何にもヒットしていない場合もリセット
            isHitting = false;
        }



        if(hokori_cnt < 4 && flameFlg == 0　&& FireCome == 0)
        {
            flame.SetActive(true);
           ShowGameText2("オーブンが燃えました！　消火器を入手して消してください！");
        }

        if(Firefrg == 1&& heitaicFlg != 1)
        {
            ShowGameText("エンター長押しで噴射");
        }

        
        if (hokori_cnt < 1 && flameFlg == 0)
        {
            
            Fire.GetComponent<OutlineBehaviour>().enabled = true;
            Fire.GetComponent<OutlineBehaviour>().OutlineColor = UnityEngine.Color.red;


            if (a < b1 + b2  && Firefrg == 0)
            {
                FireCome = 1;
                SetText("取得する:Nキー");
                if (Input.GetKeyDown(KeyCode.N))
                {
                    HideGameText2();
                    audioSource.PlayOneShot(ItemClip);
                    audioSource.clip = fire_extClip;
                    ShowGameText("消火器を入手した。");
                    itemImage.sprite = fireExtinguisherSprite;
                    Fire.SetActive(false);
                    Firefrg = 1;//消火器を取得したかのフラグ
                }
            }

           
            
        }else　if(flameFlg == 0 && a < b1 + b2)
            if(WaterFrg == 0 || HandiFlg == 0)
        {
            ShowGameText("取得できません");
        }
        if (Firefrg == 1 && Input.GetKey(KeyCode.Return) && PreFlg == 0)
        {
            if (!audioSource.isPlaying)  // すでに再生されていない場合のみ再生
            {

                audioSource.PlayOneShot(fire_extClip);//good!
            }

            WaterObj.SetActive(true);//消火器噴射
            
        }
        else 
        
        {
            WaterObj.SetActive(false);
        }

        if (PreFlg == 1)
          {
           
          

            if (r < c1 + c2 && PreCome == 0)
            {
                ShowGameText("取得する:Nキー");
                pressureCleaner.GetComponent<OutlineBehaviour>().enabled = true;
                if (Input.GetKeyDown(KeyCode.N))
                {
                    audioSource.PlayOneShot(ItemClip);
                    audioSource.clip = WaterSpClip;
                    itemImage.sprite = PressureCleanerSprite;
                    pressureCleaner.SetActive(false);
                    PreCome = 1;
                    CleanerFlg = 1;
                    
                }
            }
          }
        else if(PreFlg == 0 && r < c1 + c2 )
        {
            if (WaterFrg == 0 || HandiFlg == 0 || Firefrg == 0)
            {
               ShowGameText("まだ入手できません");
            }
        }

   
    

      
     if(CleanerFlg == 1 )
        {
            Startcnt = 0;
            ShowGameText2( "高圧洗浄機を手に入れた！\nエンター長押しで水噴射");
            ShowGameText("壁の汚れを落とそう！");
        }

    
        

        if(CleanerFlg == 1 && Input.GetKey(KeyCode.Return))
        {
            if (!audioSource.isPlaying)  // すでに再生されていない場合のみ再生
            {

                audioSource.PlayOneShot(WaterSpClip);//good!
            }
           
            CleanerObj.SetActive(true);
        }else
        {
          
            CleanerObj.SetActive(false);
        }

        if(flameFlg == 1)
        {
            youCube.SetActive(true);//Youcubeを表示
        }
        else
        {
            youCube.SetActive(false);//Youcubeを非表示
        }


       if(CleanerFlg == 1 && YogoreCnt >= 1)
        {
           ShowGameText2("汚れ残り" + YogoreCnt + "だよ");
        }else if(YogoreCnt == 0 && heitaicFlg == 0)
        {
            gameText.gameObject.SetActive(false);
            gameText2.gameObject.SetActive(false);
           ShowGameText2("汚れ残り0だよ");
        }

        if(IFlg == 0)
        {
            ICube.SetActive(false);
        }
        else if(IFlg == 1)
        {
            ICube.SetActive(true);
        }

      

        if (YogoreCnt < 1 && heitaicFlg == 0)
        {
            audioSource.PlayOneShot(heitaiClip);
            heitai_c.SetActive(true);
            IFlg = 1;

            if (hit.collider.CompareTag("heitaic"))
            {
                ShowGameText("入手する:Nキー");


            }
            if (hit.collider.CompareTag("heitaic") && Input.GetKeyDown(KeyCode.N))
            {
              
              audioSource.PlayOneShot(ItemClip);
               ShowGameText2("兵隊Cを手に入れた！\n兵隊を置ける場所を探そう");
               
                heitai_c.SetActive(false);
                audioSource.PlayOneShot(ItemClip);
                itemImage.sprite = HeitaicSprite;
                heitaicFlg = 1;
                CleanerFlg = 0;
                HideGameText();
                Timer = 0;//タイマーをリセット
                if (IFlg == 1)
                {
                    ICube.SetActive(true);
                }

            }
        }

        

        if(hit.collider.CompareTag("HeitaiCap") && heitaicFlg == 1 && tFlg == 0)
        {
            HideGameText2();
           ShowGameText("エンターで兵隊を置く");
           
            Timer += Time.deltaTime;
            if (Timer > 0.3f)
            {
                capsule.GetComponent<OutlineBehaviour>().OutlineColor = UnityEngine.Color.red;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                   
                    audioSource.PlayOneShot(angelClip);
                    ShowGameText2("兵隊Cを置いた");
                    itemImage.sprite = nothingSprite;
                    capsule.GetComponent<OutlineBehaviour>().enabled = false;
                    heitai_kc.SetActive(true);
                    text1.GetComponent<HMasseage>().TextFlg = 1;
                    Timer = 0;
                    tFlg = 1;
                    
                }
            }
        }
        
       
       
       

        if(tFlg == 1)

        {
            HintTimer += Time.deltaTime;
            Timer += Time.deltaTime;
            if (hntFlg == 0)
            {
                HintPhoto.SetActive(true);
                if (hit.collider.CompareTag("Hint"))
                {
                    ShowGameText("取得する:Nキー");
                    HintPhoto.GetComponent<OutlineBehaviour>().enabled = true;
                }

                if (Input.GetKeyDown(KeyCode.N))
                {
                   ShowGameText2("パスワードのヒントを手に入れた");
                    HintPhoto.SetActive(false);
                    itemImage.sprite = HintSprite;
                    hntFlg = 1;
                }                          
            }

            //if (HintTimer >= 25f)
           


            if (Timer > 3f)
            {
                text2.GetComponent<HMasseage2>().TextFlg2 = 1;
            }
            if(Timer >  6f)
            {
                text3.GetComponent<HMasseage3>().TextFlg3 = 1;
            }
            if(Timer > 8f)
            {
                text4.GetComponent<HMasseage4>().TextFlg4 = 1;
            }
            if(Timer > 11f)
            {
                text5.GetComponent<HMasseage5>().TextFlg5 = 1;
            }
            if(Timer > 14f)
            {
                text6.GetComponent<HMasseage6>().TextFlg6 = 1;
            }
            if(Timer > 16f)
            {
                text7.GetComponent<HMasseage7>().TextFlg7 = 1;
            }


        }


        if(hntFlg == 1)
        {
          ShowGameText2("ヒントを見る。\n[エンター長押し]");
            if (Input.GetKey(KeyCode.Return))
            {
                f += Time.deltaTime;
                if (f > 1f)
                {
                    HintUI.SetActive(true);

                }
            }
            else
            {
                f = 0f;
                HintUI.SetActive(false);
            }
        }


        if(gameobject.GetComponent<Password>().PassFlg == 1 && q < 1f )//パスワードで写真の入手まで 
        {
            photo.GetComponent<OutlineBehaviour>().enabled = true;
            HideGameText2();

            if( hit.collider.CompareTag("Quad") && Input.GetKeyDown(KeyCode.N))
            {
                audioSource.PlayOneShot(ItemClip);
                itemImage.sprite = photoSprite;
                photo.SetActive(false);
                photoFlg = 1;
            }
            
        }

        if(photoFlg == 1)
        {
            ShowGameText("家族写真を手に入れた");
            i += Time.deltaTime;
            if(i > 3f)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }

        if(gameobject.GetComponent<Password>().PassFlg == 1)
        {
            j += Time.deltaTime;

            if(j > 2f)
            {
                chest.SetActive(false);
            }
        }



            if (Input.GetKey(KeyCode.A))         //左を向く
            {
                transform.Rotate(new Vector3(0, -1, 0));
            }
            if (Input.GetKey(KeyCode.D))         // 右を向く
            {
                transform.Rotate(new Vector3(0, 1, 0));
            }

        if (Input.GetKey(KeyCode.W))         //上を向く
        {
            currentXRotation = Mathf.Clamp(currentXRotation - 1f, -rotationLimit, rotationLimit);
        }
        if (Input.GetKey(KeyCode.S))         //下を向く
        {
            currentXRotation = Mathf.Clamp(currentXRotation + 1f, -rotationLimit, rotationLimit);
        }

        // 現在の回転を保持しながら、X軸の回転のみ更新
        Quaternion newRotation = Quaternion.Euler(currentXRotation, transform.eulerAngles.y, 0.02f);
        transform.rotation = newRotation;

        // スペースキーが押されたらしゃがみ状態をトグルする
        if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleCrouch();
           
            }
            void ToggleCrouch()
            {
                // しゃがみ状態をトグル
                isCrouching = !isCrouching;

                // しゃがみ状態に応じて位置を調整
                if (isCrouching)
                {
                    transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);//しゃがんでいる目線の高さ
                    SyagamiFlg = 1;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 1.4f, transform.position.z);//立ち上がっている目線の高さ
                    SyagamiFlg = 0;
                }

            }

        

      
        



    }
    void SetText(string newText)
    {
     
        TextComment.text = newText;
    }



    // gameTextの表示/非表示を制御する関数
    private void ShowGameText(string message)
    {
        if (gameText != null)
        {
            gameText.gameObject.SetActive(true);
            gameText.text = message;
        }
    }

    private void HideGameText()
    {
        if (gameText != null)
        {
            gameText.gameObject.SetActive(false);
        }
    }

    // gameText2の表示/非表示を制御する関数
    private void ShowGameText2(string message)
    {
        if (gameText2 != null)
        {
            gameText2.gameObject.SetActive(true);
            gameText2.text = message;
        }
    }

    private void HideGameText2()
    {
        if (gameText2 != null)
        {
            gameText2.gameObject.SetActive(false);
        }
    }

    // 両方のテキストを非表示にする関数
    private void HideAllGameTexts()
    {
        HideGameText();
        HideGameText2();
    }




    private void FixedUpdate()
    {
        //Camera.main.transform.forwardはメインカメラが向いているワールド座標
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //new Vector3(1, 0, 1)でY軸を0にすることで前後移動に制限している

        Vector3 moveForward = cameraForward * inputVertical;
        //cameraForwardは水平方向への移動ベクトル　Verticalで入力されたWとSの入力をpersonの前後移動にする
        rb.velocity = moveForward * moveSpeed;

       /* if(inputVertical == 1 || inputVertical == -1)移動した時に足音を出す
        {
            GetComponent<AudioSource>().Play();
        }else if(inputVertical == 0)
        {
            GetComponent<AudioSource>().Stop();
        }*/
        
        //移動ベクトルのmoveForwardに移動スピードをかけてそれをプレイヤーのRigidbody の速度に設定

    }
    /* private void OnTriggerEnter(Collider other)
     {


         if (other.gameObject.tag == "Renti" && WaterFrg == 1)//タグがレンチかつウォーターフラグが１のとき
         {


                 Debug.Log("レンチを入手した！");
                 WaterFrg = 2;


         }
         else if(other.gameObject.tag == "Fire")//タグが消火器なら
         {

                 Debug.Log("消火器を入手した。");

             Fire_frg++;
         }else if(other.gameObject.tag == "Souzi")//タグが掃除機なら
         {

                 Debug.Log("掃除機を入手した。");
                 Soziki_frg++;

         }



     }*/



}
