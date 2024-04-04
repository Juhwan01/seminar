using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform nextPos;
    public Image hpBar;
    public GameObject overSet;

    // Update is called once per frame
    void Update()
    {
        ArrowDown();
    }
    public void ArrowDown() 
    {
        // 프레임마다 등속으로 낙하시킨다 
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다
        if (transform.position.y < -5.0f)
        {
            transform.position = nextPos.position;
        }

        // 충돌 판정
        Vector2 p1 = transform.position;              // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position;  // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;  // 화살의 반경
        float r2 = 1.0f;  // 플레이어의 반경

        if (d < r1 + r2)
        {
            // 충돌한 경우는 화살을 지운다
            transform.position = nextPos.position;
            hpBar.fillAmount -= 0.25f;
            if (hpBar.fillAmount <= 0) 
            {
                player.SetActive(false);
                overSet.SetActive(true);
            }
        }

    }
}
