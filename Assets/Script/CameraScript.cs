using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
   
    public float targetZ = -0.7f; // 移動先のZ座標
    public float moveSpeed = 1f; // 移動速度
    public float lookSpeed = 2f; // 視線の移動速度
    private int Zflg = 0;
    public  int Zopen =0;
    float Speed = 6f;
    float over = 0f;
    public int TextFlg = 0;
    private bool invincible = false;
    public float invincibilityDuration = 6f;//無敵時間
    public GameObject[] lifeArray = new GameObject[2];
    GameObject GateDoor;//ドア
    GameObject GateCollider;
    private GameObject leftDoor;  // 左ドア
    private GameObject rightDoor; // 右ドア
    private BoxCollider leftDoorCollider;  // 左ドアのBoxCollider
    private BoxCollider rightDoorCollider; // 右ドアのBoxCollider
    private int lifePoint = 2;
    public Image hpImage, hpImage2;
    public Image fullScreenImage; // フルスクリーンのRawImage

     float totalTime = 30f; // 制限時間（秒）
    private float currentTime; // 現在の経過時間
    public Text timerText; // 制限時間を表示するUI Text
    private bool isTimerRunning = true;//制限時間を止めたり

    [SerializeField] private AudioSource s1;//音を出す本体スピーカー
    [SerializeField] private AudioClip b1;//cdみたいな　効果音のデータ

    GameObject door;//ドア
    
    private bool lockZAxis = true; // Z軸をロックするためのフラグ
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        door = GameObject.Find("DoorSingle");
        GateDoor = GameObject.Find("DoorDouble");
        GateCollider = GameObject.Find("WallCollider (20)");

        // ドアの取得
        leftDoor = GameObject.Find("leftDoor");
        rightDoor = GameObject.Find("rightDoor");


        door.SetActive(false);

        hpImage.enabled = false;
        hpImage2.enabled = false;
        fullScreenImage.enabled = false;
        currentTime = totalTime;
        timerText.gameObject.SetActive(false);

        // BoxColliderの取得
        if (leftDoor != null)
        {
            leftDoorCollider = leftDoor.GetComponent<BoxCollider>();
            Debug.Log("左ドアのBoxCollider取得完了");
        }
        if (rightDoor != null)
        {
            rightDoorCollider = rightDoor.GetComponent<BoxCollider>();
            Debug.Log("右ドアのBoxCollider取得完了");
        }
    }
    void Update()
    {

        if (TextFlg == 1　&& isTimerRunning)
        {
            timerText.gameObject.SetActive(true);
            hpImage.enabled = true;
            hpImage2.enabled = true;
            // 制限時間をUI Textに表示
            UpdateTimerUI();
            currentTime -= Time.deltaTime;
            if (Zopen == 1)
            {
                lockZAxis = false;
            }


            if (Zflg == 1)
            {
                targetZ = transform.position.z;
            }
            // 前進
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.A))         //左を向く
        {
            transform.Rotate(0f, -4f, 0f);
        }
        if (Input.GetKey(KeyCode.D))         // 右を向く
        {
            transform.Rotate(0f, 4f, 0f);
        }
        if (lockZAxis)
        {
            // 現在のZ座標を取得
            float currentZ = transform.position.z;
            // 目標のZ座標にゆっくり近づける
            float newZ = Mathf.MoveTowards(currentZ, targetZ, moveSpeed * Time.deltaTime);

            // 新しい座標を設定
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);


            if (Zflg == 0)
            {
                // 目標に到達したかを確認
                if (Mathf.Approximately(newZ, targetZ))
                {
                    // 到達した場合に任意の処理を追加する
                    Debug.Log("目標に到達しました");
                    Zflg = 1;
                    door.SetActive(true);
                }

            }
        }
       
        if(lifePoint == 0)
        {
            over += Time.deltaTime;
            fullScreenImage.enabled = true;
            SET1();
            isTimerRunning = false;

            if (over >= 3f)
            {
                SceneManager.LoadScene("GameOverScene");
            }

        }

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            TimeUp();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("father") && !invincible)
        {

            // プレイヤーを無敵状態にする
            invincible = true;

            // 一定時間後に無敵状態を解除するコルーチンを開始
            StartCoroutine(DisableInvincibilityAfterDuration());
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }

   

    // 一定時間後に無敵状態を解除するコルーチン
    private System.Collections.IEnumerator DisableInvincibilityAfterDuration()
    {
        yield return new WaitForSeconds(invincibilityDuration);

        // 無敵状態を解除
        invincible = false;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // 制限時間を分と秒の形式で表示
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void TimeUp()
    {
       
        // ドアのコライダーを無効化
        if (leftDoorCollider != null)
        {
            leftDoorCollider.enabled = false;
            Debug.Log("左ドアのコライダーを無効化しました");
        }
        else
        {
            Debug.LogWarning("左ドアのBoxColliderが見つかりません");
        }

        if (rightDoorCollider != null)
        {
            rightDoorCollider.enabled = false;
            Debug.Log("右ドアのコライダーを無効化しました");
        }
        else
        {
            Debug.LogWarning("右ドアのBoxColliderが見つかりません");
        }

        GateDoor.SetActive(false);
        GateCollider.SetActive(false);
    }

    public void SET1()
    {
        s1.PlayOneShot(b1);//a1にアタッチしたAudioSourceの設定値でb1にアタッチした効果音を再生
    }
}
