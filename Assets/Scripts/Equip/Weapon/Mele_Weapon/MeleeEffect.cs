using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEffect : Effect
{
    public GameObject hitbox_Down;
    public GameObject hitbox_Left_Down;
    public GameObject hitbox_Left_Up;
    public GameObject hitbox_Right_Down;
    public GameObject hitbox_Right_Up;
    public GameObject hitbox_Up;


    public void Enable_Down_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 1)
        {
            hitbox_Down.SetActive(true);
            hitbox_Down.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z + 1);
        }


    }
    public void Disable_Down_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 1)
        {
            hitbox_Down.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z - 1);
            hitbox_Down.SetActive(false);
        }

    }

    public void Enable_LeftDown_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 2)
        {
            hitbox_Left_Down.SetActive(true);
            hitbox_Left_Down.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z+1);
        }
    }
    public void Disable_LeftDown_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 2)
        {
            hitbox_Left_Down.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z -1);
            hitbox_Left_Down.SetActive(false);
        }
    }

    public void Enable_LeftUp_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 3)
        {
            hitbox_Left_Up.SetActive(true);
            hitbox_Left_Up.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z + 1);
        }

    }
    public void Disable_LeftUp_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 3)
        {
            hitbox_Left_Up.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z - 1);
            hitbox_Left_Up.SetActive(false);
        }

    }

    public void Enable_RightDown_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 4)
        {
            hitbox_Right_Down.SetActive(true);
            hitbox_Right_Down.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z + 1);
        }

    }
    public void Disable_RightDown_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 4)
        {
            hitbox_Right_Down.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z - 1);
            hitbox_Right_Down.SetActive(false);
        }

    }

    public void Enable_RightUp_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 5)
        {
            hitbox_Right_Up.SetActive(true);
            hitbox_Right_Up.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z + 1);
        }

    }
    public void Disable_RightUp_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 5)
        {
            hitbox_Right_Up.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z - 1);
            hitbox_Right_Up.SetActive(false);
        }

    }

    public void Enable_Up_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 6)
        {
            hitbox_Up.SetActive(true);
            hitbox_Up.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z + 1);
        }

    }
    public void Disable_Up_Hitbox()
    {
        if (CharacterRef.AnimationNumber == 6)
        {
            hitbox_Up.transform.position = new Vector3(CharacterRef.transform.position.x, CharacterRef.transform.position.y, CharacterRef.transform.position.z - 1);
            hitbox_Up.SetActive(false); 
        }

    }
}
