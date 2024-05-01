using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBoard : MonoBehaviour
{
    public GameObject board;
    public GameObject boardPrefab;

    // 使用预制件进行算盘重置
    public void BoardReset()
    {
        GameObject newBoard = Instantiate(boardPrefab, board.transform.position, board.transform.rotation);
        newBoard.GetComponent<Board>().sumUI = board.GetComponent<Board>().sumUI;
        Destroy(board);
        board = newBoard;
    }
}
