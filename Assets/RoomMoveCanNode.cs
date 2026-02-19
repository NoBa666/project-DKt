using UnityEngine;
using System.Collections.Generic;

public class RoomMoveCanNode : MonoBehaviour
{
    [Header("이동 가능한 방")]
    public List<RoomMoveCanNode> nextRooms = new List<RoomMoveCanNode>();
}