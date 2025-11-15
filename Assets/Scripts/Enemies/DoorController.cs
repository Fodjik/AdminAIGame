using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject closedDoorGraphic;
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void CloseDoor()
    {
        col.enabled = true;
        closedDoorGraphic.SetActive(true);
    }

    public void OpenDoor()
    {
        col.enabled = false;
        closedDoorGraphic.SetActive(false);
    }
}
