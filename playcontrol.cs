using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playcontrol : MonoBehaviour {
        private Rigidbody2D mybody;
    private Animator anim;
    public bool checkdie;

	void Start () {
		checkdie = false;
	}
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Control();
    }
	public void Control()
    {
        float forceX = 0f;
        float forceY = 0f;
        float velo = Mathf.Abs(mybody.velocity.x);
        float key = Input.GetAxisRaw("Horizontal");

        if (key > 0) // khi nhan D
        {
            // kiem tra gia toc
            if (velo < 4f)
            {
                forceX = 15f;
            }
            anim.SetBool("walked", true);
            Vector2 scale = transform.localScale;
            scale.x = 1.5f;
            transform.localScale = scale;
        }
        else if (key < 0)
        {
            if (velo < 4f)
            {
                forceX = -15f;
            }
            anim.SetBool("walked", true);
            Vector2 scale = transform.localScale;
            scale.x = -1.5f;
            transform.localScale = scale;
        }else
        {
            anim.SetBool("walked", false);
        }
        // xe truong hop nhay
		if (Input.GetKey(KeyCode.Space))
		{
            
                forceY = 30f;
                anim.SetBool("jump", true);
            
        }
        if (checkdie)
        {
            anim.SetBool("playdie", true);
        }
        mybody.AddForce(new Vector2(forceX,forceY));
    }
  
    
}
