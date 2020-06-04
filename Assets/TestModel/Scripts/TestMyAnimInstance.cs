using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyAnimInstance : MonoBehaviour
{
    public GameObject prefabA;
    public int showCount = 0;
    List<AnimationInstancing.AnimationInstancing> listAniInstan = new List<AnimationInstancing.AnimationInstancing>();
    //AnimationInstancing.AnimationInstancing animInstance;
    //GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        LoadAB();
        Clear();
        AnimationInstancing.AnimationInstancingMgr.Instance.UseInstancing = true;

        StartCoroutine(CreateRoles());

    }

    private IEnumerator CreateRoles()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < showCount; i++)
        {
            int randomInt = Random.Range(0, 10);
            GameObject go = CreateInstance();
            AnimationInstancing.AnimationInstancing animInstance = go.GetComponent<AnimationInstancing.AnimationInstancing>();

            animInstance.PlayAnimation(randomInt);
            listAniInstan.Add(animInstance);
        }
    }

    void LoadAB()
    {
        StartCoroutine(AnimationInstancing.AnimationManager.Instance.LoadAnimationAssetBundle(Application.streamingAssetsPath + "/AssetBundle/animationtexture"));
    }

    GameObject CreateInstance()
    {
        GameObject go = null;
        if (AnimationInstancing.AnimationInstancingMgr.Instance.UseInstancing)
        {
            if (prefabA != null)
            {
                go = AnimationInstancing.AnimationInstancingMgr.Instance.CreateInstance(prefabA);
                go.transform.position = new Vector3(0, 0, 0);
            }
        }
        return go;
    }

    void Clear()
    {
        AnimationInstancing.AnimationInstancingMgr.Instance.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < listAniInstan.Count; i++)
            {
                //int randomInt = Random.Range(0, 10);
                //listAniInstan[i].PlayAnimation(randomInt);
                listAniInstan[i].PlayAnimation("attack");
            }
        }
        
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    animInstance.CrossFade("walk", 0.2f);
        //}else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    animInstance.CrossFade("attack", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.C))
        //{
        //    animInstance.CrossFade("clamb", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    animInstance.CrossFade("dead", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.H))
        //{
        //    animInstance.CrossFade("hit", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.I))
        //{
        //    animInstance.CrossFade("idle", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.R))
        //{
        //    animInstance.CrossFade("run", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    animInstance.CrossFade("skill1", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    animInstance.CrossFade("hurt", 0.2f);
        //}
        //else if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    animInstance.CrossFade("skill2", 0.2f);
        //}
    }
}
