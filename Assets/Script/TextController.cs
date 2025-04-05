using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textComponent;
    public float i = 0;
    public float j = 0;
    public float m = 0;
    float chatFlg1, chatFlg2, chatFlg3,chatFlg4,chatFlg5,chatFlg6,chatFlg7,chatFlg8,chatFlg9,chatFlg10,chatFlg11, chatFlg12 = 0;//�t���O�ɂO������
    public int PaperFlg = 0;
    GameObject yes, no;
    public GameObject paper;
    public GameObject wall;

   
     
    
    private void Start()
    {

        // �����̃e�L�X�g��ݒ�
        SetText("��H�����");

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
            SetText("�p�p�ƃ}�}����Ȃ���");
        }
        else if (chatFlg2 == 1 && chatFlg3 == 0 )
        {
            SetText("�悤�I�v���Ԃ肾��");
        }
        else if (chatFlg3 == 1 && chatFlg4 == 0 )
        {
            SetText("�܂��I�Ƒ��ʐ^�Ȃ�Ă݂��̉��\�N�Ԃ肩����");
        } else if (chatFlg4 == 1 && chatFlg5 == 0 )
        {
            SetText("�Ō�ɂ��O�ɉ�Ă悩������B");
        } else if (chatFlg5 == 1 && chatFlg6 == 0 )
        {
            SetText("�����ˁB����ōŌ�Ȃ̂��...");
        }
        else if (chatFlg6 == 1 && chatFlg7 == 0 )
        {
            SetText("�Ō���Ăǂ��������Ƃ���H");
        }else if(chatFlg7 ==1 && chatFlg8 == 0 )
        {
            SetText("�p�p�̃Y�{�����牽�������Ď����̑����ɁB");

            PaperFlg = 1;

        }
        else if (chatFlg8 == 1 && chatFlg9 == 0 )
        {
            SetText("�����ƁI����͂܂����I");
           
        } 
        else if (chatFlg9 == 1  && chatFlg10 == 0 )
        {
            SetText("�����Ⴍ����ɂȂ����V����");
           

        }
        else if (chatFlg10 == 1 && chatFlg11 == 0)
        {
            SetText("�V���ɂ͗��e�����̂ŖS���Ȃ����L��������");

        }
        else if (chatFlg11 == 1 && chatFlg12 == 0)
        {
            SetText("�M���Ă���@�킵�����͎���łȂ���");

        }
        else if (chatFlg12 == 1 )
        {
            SetText("�M���܂����H");
            m += Time.deltaTime;
            if(m > 2f)
            {
                textComponent.gameObject.SetActive(false);
            }
          
        }
        //�V���������Ď�l���͗��e�����񂾐V����ǂ݁@�M���Ă���킵�����͎���łȂ��񂾁@�͂��@�������@�ŐM���邩�ǂ��������߂�
        //�M����΂킵�����͂������Ă����ƉƑ����B�ƌ����V�ɏ������
        //�M���Ȃ���΁@�k���񂪖ꂳ�����Ă����܂��I�@�@�{���Ėꂳ�񂪏P���|�����ė���@�P���ԍU�����󂯂Ȃ���΁@�����̔����J���ĒE�o�����@


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
        // Text�R���|�[�l���g��text�v���p�e�B���g�p���ăe�L�X�g��ύX
        textComponent.text = newText;
    }
  
    public void Shoot(Vector3 dir)
    {
       
            paper.GetComponent<Rigidbody>().AddForce(dir);
        
    }
}