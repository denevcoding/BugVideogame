using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class DissolveController : MonoBehaviour
{
    //public Renderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    public Material DissolveMat;

    //private Material[] skinnedMaterials;
    public List<Material> allMaterials = new List<Material>();

   

    public void Dissolve()
    {
        SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer rendCpomp in renderers)
        {
            Material[] mats = rendCpomp.materials;
            for (int i = 0; i < rendCpomp.materials.Length; i++)
            {
                mats[i] = DissolveMat;
                allMaterials.Add(mats[i]);
            }

            rendCpomp.materials = mats;
        }

        //skinnedMesh.material = DissolveMat;
        StartCoroutine(DissolveCo());
    }


    IEnumerator DissolveCo()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }




        if (allMaterials.Count > 0)
        {
            for (int i = 0; i < allMaterials.Count; i++)
            {
                float counter = 0;
                while (allMaterials[i].GetFloat("_DissolveAmount") < 1)
                {
                    counter += dissolveRate;
                    allMaterials[i].SetFloat("_DissolveAmount", counter);
                    yield return new WaitForSeconds(refreshRate);
                }
            }
        }

        //if (skinnedMaterials.Length > 0)
        //{
        //    float counter = 0;

        //    while (skinnedMaterials[0].GetFloat("_DissolveAmount") < 1)
        //    {
        //        counter += dissolveRate;
        //        for (int i = 0; i < skinnedMaterials.Length; i++)
        //        {
        //            skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
        //        }
               
        //    }


        //}
    }
}
