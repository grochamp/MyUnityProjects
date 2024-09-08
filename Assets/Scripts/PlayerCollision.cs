using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public EncounterController encounterController;  // EncounterController 참조

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            encounterController.TriggerEncounter();  // EncounterController에 충돌 이벤트 전달
        }
    }
}
