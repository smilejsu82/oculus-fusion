using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationTest : MonoBehaviour
{
    [SerializeField] private Button btnHold;
    [SerializeField] private Button btnFlex;

    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        this.btnHold.onClick.AddListener(() =>
        {
            Debug.Log("Hold");
            this.anim.SetInteger("Pose", 1);
        });
        this.btnFlex.onClick.AddListener(() =>
        {
            Debug.Log("Flex");
            this.anim.SetInteger("Pose", 0);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
