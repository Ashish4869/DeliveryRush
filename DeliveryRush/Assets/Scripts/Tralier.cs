using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tralier : MonoBehaviour
{
    /// <summary>
    /// Starts car
    /// </summary>
    /// 

    [SerializeField]
    NPC npc;

    [SerializeField]
    Animator notifAnimator;

    public void StartNPC()
    {
        npc.enabled = true;
    }

    public void PlayNotif()
    {
        notifAnimator.SetTrigger("Animate");
    }
}
