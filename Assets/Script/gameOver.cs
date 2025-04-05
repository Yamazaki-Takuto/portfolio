using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameOver : MonoBehaviour
{
    float i = 0f;
    public Image Image;
    [SerializeField] private AudioSource a1;
    [SerializeField] private AudioSource a2;

    [SerializeField] private AudioClip b1;
    [SerializeField] private AudioClip b2;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Image.enabled = false;
        // AudioSource�R���|�[�l���g�̎擾
        audioSource = gameObject.AddComponent<AudioSource>();

        // AudioClip�̐ݒ�
        audioSource.clip = b1;

        // ���ʉ�1�̍Đ�
        SE1();
    }

    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        if(i >= 7f)
        {
            Image.enabled = true;
            // AudioClip�����ʉ�2�ɕύX
        audioSource.clip = b2;

            // ���ʉ�2�̍Đ�
            SE2();
        }
    }
    public void SE1()
    {
        a1.PlayOneShot(b1);//a1�ɃA�^�b�`����AudioSource�̐ݒ�l��b1�ɃA�^�b�`�������ʉ����Đ�
    }

    //����̊֐�2
    public void SE2()
    {
        a2.PlayOneShot(b2);//a2�ɃA�^�b�`����AudioSource�̐ݒ�l��b2�ɃA�^�b�`�������ʉ����Đ�
    }
}
