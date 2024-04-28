using UnityEngine;
using UnityEngine.EventSystems;


public class SelectTrigger : MonoBehaviour
{
    [Header("鼠标点击触发")]
    public bool canBeClick = false;

    [Header("角色触碰触发")]
    public bool canBeTouch = false;

    [Header("角色点击触发")]
    public bool canBeSelect = false;

    [Header("可被赋予物品")]
    public bool canBeDragTo = false;

    private bool isCursor = false;
    private bool isPlayer = false;

    public ClickDelegate Click;
    public TouchDelegate Touch;
    public SelectDelegate Select;
    public DragToDelegate DragTo;

    private Global global = Global.Instance;

    void Start()
    {

    }

    void Update()
    {
        // 鼠标点击触发
        if (canBeClick && Input.GetMouseButtonDown(0) && isCursor)
        {
            Click();
        }

        // 角色触碰触发
        if (canBeTouch && isPlayer)
        {
            Touch();
        }

        // 角色点击触发
        if (canBeSelect && global.IsClickNotOnUI() && isPlayer && isCursor)
        {
            Select();
        }

        // 拖拽触发
        if (canBeDragTo && Input.GetMouseButtonUp(0) && isCursor && global.itemBeDrag != null)
        {
            global.willDragTo = false;
            DragTo();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            isCursor = true;
            global.willDragTo = canBeDragTo;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            global.willDragTo = isCursor = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}