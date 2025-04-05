using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldScript : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float speedIncreaseAmount = 2f; // 速度の増加量
    public float rayDistance = 1f; // Rayの距離
    GameObject gameObject1;
    public int moveFlg = 0;
    Animator animator;
    Vector3 movement;
    float i = 0f;
    float speedTimer = 0f; // 速度増加用のタイマー

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

            // 10秒ごとに速度を増加
            if (speedTimer >= 10f)
            {
                moveSpeed += speedIncreaseAmount;
                speedTimer = 0f; // タイマーをリセット
                Debug.Log("Speed increased to: " + moveSpeed); // 速度確認用
            }

            // 移動方向を現在のTransformのforward方向として設定
            movement = transform.forward * moveSpeed * Time.deltaTime;

            // Raycastで壁との衝突を検知
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                // 壁に当たったら反射
                Vector3 reflectDirection = Vector3.Reflect(transform.forward, hit.normal);
                reflectDirection.y = 0; // Y軸の反射を防ぐ
                transform.forward = reflectDirection.normalized;

                // デバッグ用
                Debug.DrawRay(transform.position, reflectDirection * 2, Color.red, 0.1f);
                Debug.Log("壁に当たって反射: " + hit.collider.name);
            }

            // 移動を適用
            transform.Translate(movement, Space.World);
        }
    }
    // デバッグ用に反射の様子を可視化
    void OnDrawGizmos()
    {
        // 前方向のRayを描画
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}
