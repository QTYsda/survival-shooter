using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float Speed = 8;
    private Rigidbody rb;
    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        移动代码(h, v);
        旋转代码();
        动画代码(h,v);
    }
    void 移动代码(float h, float v)
    {
        Vector3 movement3 = new Vector3(h, 0, v);
        movement3 = movement3.normalized * Speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement3);
    }
    void 旋转代码()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        int floorLayer = LayerMask.GetMask("地面");
        RaycastHit 交点;
        bool 触碰地面 = Physics.Raycast(cameraRay,out 交点, 100, floorLayer);
        if(触碰地面)
        {
            Vector3 距离 = 交点.point - transform.position;
            距离.y = 0;
            Quaternion quaternion = Quaternion.LookRotation(距离);
            rb.MoveRotation(quaternion);
        }
    }
    void 动画代码(float h ,float v)
    {
        bool isw = h != 0 || v != 0;
            anim.SetBool("Walking",isw);
    }
}
