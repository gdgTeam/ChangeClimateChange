using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Die")]
    public class Die : StateData
    {
        GameObject piantina;
        GameObject player;
        GameObject zainetto;
        Material[] piantinaMaterials;
        Material[] zainettoMaterial;
        float add;


        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            piantina = player.GetComponent<CharacterControl>().piantina;
            zainetto = player.GetComponent<CharacterControl>().zainetto;

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (animator.GetBool("Morte"))
            {
                add = add + 0.005f;
                piantinaMaterials = piantina.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                zainettoMaterial = zainetto.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                piantinaMaterials[0].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[1].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[2].SetFloat("Vector1_ACBAB4A6", add);
                piantinaMaterials[3].SetFloat("Vector1_ACBAB4A6", add);
            }
            


        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            control.Die = true;
            //add = add + 0.01f;


            if (animator.GetBool("FallToDie"))
            {
                //  Debug.Log("Robot");
                animator.SetBool("FallToDie", false);
            }
            if (animator.GetBool("Morte"))
            {
                animator.SetBool("Morte", false);
                piantinaMaterials = piantina.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                zainettoMaterial = zainetto.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
                piantinaMaterials[0].SetFloat("Vector1_ACBAB4A6", 0);
                piantinaMaterials[1].SetFloat("Vector1_ACBAB4A6", 0);
                piantinaMaterials[2].SetFloat("Vector1_ACBAB4A6", 0);
                piantinaMaterials[3].SetFloat("Vector1_ACBAB4A6", 0);
                zainettoMaterial[0].SetFloat("Vector1_9ACB71BD", -0.1f);
                add = 0;


            }
           
        }
    }

}

