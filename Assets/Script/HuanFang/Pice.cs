using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pice : MonoBehaviour
{
    public int index;//记录拖拽物品数字
    public Vector3 startPos;
    private int currentGrid = -1;
    private Grid triggerGrid;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()//鼠标拖拽
    {
        if(followEnable == false)
        {
            return;//不能跟随
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );//获取3D世界鼠标位置
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseEnter()
    {
        
    }

    public bool followEnable = true;//能否跟随鼠标(默认可以)
    public bool hasPut;//是否已经放置(默认没有)
    private void OnMouseDown()//先按下，后拖拽
    {
        if(hasPut == false)
        followEnable = true;
    }

    private void OnMouseUp()//鼠标松开,停止拖拽
    {
        if(currentGrid >= 0)//放到格子上
        {
            if(currentGrid == index)//放置位置正确
            {
                hasPut = true;
                Debug.Log("放上了!");
                transform.position = triggerGrid.transform.position;
                triggerGrid.OnPutRight();
                //triggerGrid.GetComponent<Grid>().hasPut = true;//格子也被放置好了
            }
            else//放置错误
            {
                transform.position = startPos;
            }
        }
        else//没放到格子上
        {
            transform.position = startPos;//没放置成功，回到初始位置
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Grid")
        {
            Grid grid = collision.GetComponent<Grid>();
            if (!grid.hasPut)
            {
                triggerGrid = grid;//把物品位置设置好
                currentGrid = int.Parse(collision.name);
                Debug.Log("来啦！");
            }
            
            //---------------如果碰到就直接放置，走这串代码
            //if (currentGrid == index)
            //{
            //    hasPut = true;
            //    //格子下的icon显示
            //    collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //    Destroy(gameObject);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(triggerGrid != null && collision.gameObject == triggerGrid.gameObject)
        {
            currentGrid = -1;//离开当前格子，进行重置
            triggerGrid = null;
        }
       
        Debug.Log("出去了");
    }
}
