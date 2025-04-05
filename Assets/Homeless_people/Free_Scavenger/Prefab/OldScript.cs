using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldScript : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float speedIncreaseAmount = 2f; // ���x�̑�����
    public float rayDistance = 1f; // Ray�̋���
    GameObject gameObject1;
    public int moveFlg = 0;
    Animator animator;
    Vector3 movement;
    float i = 0f;
    float speedTimer = 0f; // ���x�����p�̃^�C�}�[

    private void Start()
    {
        this.gameObject1 = GameObject.Find("GameObject(1)");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moveFlg == 1)
        {
            i += Time.deltaTime;
            speedTimer += Time.deltaTime;

            // 10�b���Ƃɑ��x�𑝉�
            if (speedTimer >= 10f)
            {
                moveSpeed += speedIncreaseAmount;
                speedTimer = 0f; // �^�C�}�[�����Z�b�g
                Debug.Log("Speed increased to: " + moveSpeed); // ���x�m�F�p
            }

            // �ړ����������݂�Transform��forward�����Ƃ��Đݒ�
            movement = transform.forward * moveSpeed * Time.deltaTime;

            // Raycast�ŕǂƂ̏Փ˂����m
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                // �ǂɓ��������甽��
                Vector3 reflectDirection = Vector3.Reflect(transform.forward, hit.normal);
                reflectDirection.y = 0; // Y���̔��˂�h��
                transform.forward = reflectDirection.normalized;

                // �f�o�b�O�p
                Debug.DrawRay(transform.position, reflectDirection * 2, Color.red, 0.1f);
                Debug.Log("�ǂɓ������Ĕ���: " + hit.collider.name);
            }

            // �ړ���K�p
            transform.Translate(movement, Space.World);
        }
    }
    // �f�o�b�O�p�ɔ��˂̗l�q������
    void OnDrawGizmos()
    {
        // �O������Ray��`��
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}
