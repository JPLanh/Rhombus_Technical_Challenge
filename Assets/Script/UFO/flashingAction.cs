using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashingAction : MonoBehaviour
{
    [SerializeField] Material onMaterial;
    [SerializeField] Material offMaterial;
    private bool lv_flashing = false;
    [SerializeField] MeshRenderer lv_mesh;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flashing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator flashing()
    {
        while (true)
        {
            if (lv_flashing)
            {
                lv_mesh.material = offMaterial;
                lv_flashing = false;
            }
            else
            {
                lv_mesh.material = onMaterial;
                lv_flashing = true;
            }
            yield return new WaitForSeconds(.25f);

        }
    }
}
