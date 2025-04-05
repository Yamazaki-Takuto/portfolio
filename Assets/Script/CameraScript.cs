using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
   
    public float targetZ = -0.7f; // �ړ����Z���W
    public float moveSpeed = 1f; // �ړ����x
    public float lookSpeed = 2f; // �����̈ړ����x
    private int Zflg = 0;
    public  int Zopen =0;
    float Speed = 6f;
    float over = 0f;
    public int TextFlg = 0;
    private bool invincible = false;
    public float invincibilityDuration = 6f;//���G����
    public GameObject[] lifeArray = new GameObject[2];
    GameObject GateDoor;//�h�A
    GameObject GateCollider;
    private GameObject leftDoor;  // ���h�A
    private GameObject rightDoor; // �E�h�A
    private BoxCollider leftDoorCollider;  // ���h�A��BoxCollider
    private BoxCollider rightDoorCollider; // �E�h�A��BoxCollider
    private int lifePoint = 2;
    public Image hpImage, hpImage2;
    public Image fullScreenImage; // �t���X�N���[����RawImage

     float totalTime = 30f; // �������ԁi�b�j
    private float currentTime; // ���݂̌o�ߎ���
    public Text timerText; // �������Ԃ�\������UI Text
    private bool isTimerRunning = true;//�������Ԃ��~�߂���

    [SerializeField] private AudioSource s1;//�����o���{�̃X�s�[�J�[
    [SerializeField] private AudioClip b1;//cd�݂����ȁ@���ʉ��̃f�[�^

    GameObject door;//�h�A
    
    private bool lockZAxis = true; // Z�������b�N���邽�߂̃t���O
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        door = GameObject.Find("DoorSingle");
        GateDoor = GameObject.Find("DoorDouble");
        GateCollider = GameObject.Find("WallCollider (20)");

        // �h�A�̎擾
        leftDoor = GameObject.Find("leftDoor");
        rightDoor = GameObject.Find("rightDoor");


        door.SetActive(false);

        hpImage.enabled = false;
        hpImage2.enabled = false;
        fullScreenImage.enabled = false;
        currentTime = totalTime;
        timerText.gameObject.SetActive(false);

        // BoxCollider�̎擾
        if (leftDoor != null)
        {
            leftDoorCollider = leftDoor.GetComponent<BoxCollider>();
            Debug.Log("���h�A��BoxCollider�擾����");
        }
        if (rightDoor != null)
        {
            rightDoorCollider = rightDoor.GetComponent<BoxCollider>();
            Debug.Log("�E�h�A��BoxCollider�擾����");
        }
    }
    void Update()
    {

        if (TextFlg == 1�@&& isTimerRunning)
        {
            timerText.gameObject.SetActive(true);
            hpImage.enabled = true;
            hpImage2.enabled = true;
            // �������Ԃ�UI Text�ɕ\��
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
            // �O�i
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.A))         //��������
        {
            transform.Rotate(0f, -4f, 0f);
        }
        if (Input.GetKey(KeyCode.D))         // �E������
        {
            transform.Rotate(0f, 4f, 0f);
        }
        if (lockZAxis)
        {
            // ���݂�Z���W���擾
            float currentZ = transform.position.z;
            // �ڕW��Z���W�ɂ������߂Â���
            float newZ = Mathf.MoveTowards(currentZ, targetZ, moveSpeed * Time.deltaTime);

            // �V�������W��ݒ�
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);


            if (Zflg == 0)
            {
                // �ڕW�ɓ��B���������m�F
                if (Mathf.Approximately(newZ, targetZ))
                {
                    // ���B�����ꍇ�ɔC�ӂ̏�����ǉ�����
                    Debug.Log("�ڕW�ɓ��B���܂���");
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

            // �v���C���[�𖳓G��Ԃɂ���
            invincible = true;

            // ��莞�Ԍ�ɖ��G��Ԃ���������R���[�`�����J�n
            StartCoroutine(DisableInvincibilityAfterDuration());
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
    }

   

    // ��莞�Ԍ�ɖ��G��Ԃ���������R���[�`��
    private System.Collections.IEnumerator DisableInvincibilityAfterDuration()
    {
        yield return new WaitForSeconds(invincibilityDuration);

        // ���G��Ԃ�����
        invincible = false;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // �������Ԃ𕪂ƕb�̌`���ŕ\��
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void TimeUp()
    {
       
        // �h�A�̃R���C�_�[�𖳌���
        if (leftDoorCollider != null)
        {
            leftDoorCollider.enabled = false;
            Debug.Log("���h�A�̃R���C�_�[�𖳌������܂���");
        }
        else
        {
            Debug.LogWarning("���h�A��BoxCollider��������܂���");
        }

        if (rightDoorCollider != null)
        {
            rightDoorCollider.enabled = false;
            Debug.Log("�E�h�A�̃R���C�_�[�𖳌������܂���");
        }
        else
        {
            Debug.LogWarning("�E�h�A��BoxCollider��������܂���");
        }

        GateDoor.SetActive(false);
        GateCollider.SetActive(false);
    }

    public void SET1()
    {
        s1.PlayOneShot(b1);//a1�ɃA�^�b�`����AudioSource�̐ݒ�l��b1�ɃA�^�b�`�������ʉ����Đ�
    }
}
