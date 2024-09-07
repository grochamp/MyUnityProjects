using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private Animator animator; // 부모인 플레이어의 Animator
    private string currentAnimation; // 현재 재생 중인 애니메이션 이름
    private bool isAttacking; // 공격 중인지 여부

    void Start()
    {
        // 부모 오브젝트에서 Animator를 가져옴
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Attack1, Attack2, Attack3 중 하나인지 확인하고 공격 상태 설정
        if (stateInfo.IsName("Attack1") || stateInfo.IsName("Attack2") || stateInfo.IsName("Attack3"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    // 몬스터가 트리거 범위 안에 있을 때 호출되는 함수
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 공격 중이고 몬스터 태그를 가진 오브젝트가 있을 때만 처리
        if (isAttacking && collision.CompareTag("Monster"))
        {
            // 몬스터 오브젝트를 제거
            Destroy(collision.gameObject);
            Debug.Log("Monster destroyed during " + currentAnimation);
        }
    }

    // 몬스터가 트리거 범위에 들어왔을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // 공격 중이고 몬스터 태그를 가진 오브젝트가 있을 때만 처리
        if (isAttacking && collision.CompareTag("Monster"))
        {
            // 몬스터 오브젝트를 제거
            Destroy(collision.gameObject);
            Debug.Log("Monster destroyed during " + currentAnimation);
        }
    }
}
