using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/DieFire")]
    public class DieFire : StateData
    {
        Shader[] myShaders; 
        Material[] myMaterials;
        Material[] piantinaMaterials;
        Material[] zainettoMaterial;
        GameObject character;
        GameObject zainetto;
        GameObject piantina;
        public float add = 0;
        public float skin = -0.2f;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            add = add + 0.01f;
            skin = skin + 0.005f;
            CharacterControl control = characterState.GetCharacterControl(animator);
            character = control.transform.GetChild(0).gameObject;
            zainetto = control.transform.GetChild(3).gameObject;
            piantina = control.transform.GetChild(2).gameObject;
            myMaterials = character.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
            piantinaMaterials = piantina.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
            zainettoMaterial = zainetto.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
            myMaterials[0].SetFloat("Vector1_541598BE", skin); //pelle
            myMaterials[1].SetFloat("Vector1_10EF681C", add); //internoFelpa
            myMaterials[2].SetFloat("Vector1_4E318E1E", add); //scarpe
            myMaterials[3].SetFloat("Vector1_1EA8BE87", add); //capelli
            myMaterials[4].SetFloat("Vector1_1EA8BE87", add); //occhi
            myMaterials[5].SetFloat("Vector1_460BF25", add); //felpa
            myMaterials[6].SetFloat("Vector1_1EA8BE87", add); //pantaloni
            piantinaMaterials[0].SetFloat("Vector1_ACBAB4A6", add);
            piantinaMaterials[1].SetFloat("Vector1_ACBAB4A6", add);
            piantinaMaterials[2].SetFloat("Vector1_ACBAB4A6", add);
            piantinaMaterials[3].SetFloat("Vector1_ACBAB4A6", add);
            zainettoMaterial[0].SetFloat("Vector1_9ACB71BD", add);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            add = 0;
        }

    }
}
