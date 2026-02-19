using UnityEngine;
using System.Collections.Generic;

public class miniMap_PlayerMark_Move : MonoBehaviour
{
    [Header("현재 위치한 방")]
    public RoomMoveCanNode currentRoom;

    [Header("하이라이트 색상")]
    public Color highlightColor = Color.yellow;
    public Color normalColor = Color.white;

    private List<RoomMoveCanNode> highlightedRooms = new List<RoomMoveCanNode>();

    void Start()
    {
        if (currentRoom != null)
            MoveToRoom(currentRoom);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                RoomMoveCanNode clickedRoom = hit.collider.GetComponent<RoomMoveCanNode>();

                if (clickedRoom != null && highlightedRooms.Contains(clickedRoom))
                {
                    MoveToRoom(clickedRoom);
                }
            }
        }
    }

    void MoveToRoom(RoomMoveCanNode targetRoom)
    {
        ClearHighlights();

        currentRoom = targetRoom;
        transform.SetParent(targetRoom.transform);
        transform.localPosition = Vector3.zero;

        HighlightNextRooms();
    }

    void HighlightNextRooms()
    {
        highlightedRooms.Clear();

        foreach (RoomMoveCanNode room in currentRoom.nextRooms)
        {
            highlightedRooms.Add(room);

            SpriteRenderer sr = room.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = highlightColor;
        }
    }

    void ClearHighlights()
    {
        foreach (RoomMoveCanNode room in highlightedRooms)
        {
            SpriteRenderer sr = room.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = normalColor;
        }

        highlightedRooms.Clear();
    }
}