using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Defines object comportament when interacted with or activated.
/// Changes interaction text displayed to the player
/// </summary>
public class Interactive : MonoBehaviour
{
    [SerializeField]
    private Animator sceneTransition;

    public int loadLevel = 0;
    public enum InteractiveType {Pickable, Direct, Indirect};
    public InteractiveType type;
    public bool             isActive;
    public bool             consumesItem, usedOnAnimation, useWhenPicked, interactWhenPicked, orderedUsage, limitedItemUsageAtOnce;
    public string[]         interactionTexts;
    //public int              requirementForSize, maximumUses;


    //public string          requirementText;

    //private int            playerSize;
    private int            _curInteractionTextId, audioAux;

    [HideInInspector]
    public int             numberOfUses;

    public Interactive[]   activationChain, deactivationChain, interactionChain, requirements;
    public Texture         icon;
    public int[]           itemSizeRestriction;
    private AudioSource    interactionAudio;
    public  AudioClip[]    interactionAudioClips;
    public  AudioClip      activationAudioClip;

    private Animator        _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        interactionAudio = GetComponent<AudioSource>();
        _curInteractionTextId  = 0;
        //requirementForSize = 0;
        audioAux  = 0;
        numberOfUses = 0;

    }

    /// <summary>
    /// Sets the right interaction text to be displayed to the player depending
    /// on how many times he interacted with this object
    /// </summary>
    /// <returns></returns>
    public string GetInteractionText()
    {
        if(interactionTexts.Length > 0)
        {
            return interactionTexts[_curInteractionTextId];
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Function called by interactions that activate other objects
    /// Activates the chained object and plays the corresponding animation
    /// </summary>
    public void Activate()
    {
        isActive = true;

        if (_anim != null)
            _anim.SetTrigger("Activate");

        if(interactionAudio != null && activationAudioClip != null)
        {
            interactionAudio.PlayOneShot(activationAudioClip);
        }
    }

    /// <summary>
    /// For every object that this interaction must activate, calls the function
    /// that activates the objects
    /// </summary>
    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }

    /// <summary>
    /// Function called by interactions that deactivate other objects
    /// Deactivates the chained object and plays the corresponding animation
    /// </summary>
    public void Deactivate()
    {
        isActive = false;

        if (_anim != null)
            _anim.SetTrigger("Deactivate");
    }

    /// <summary>
    /// For every object that this interaction must deactivate, calls the
    /// function that deactivates the objects
    /// </summary>
    private void ProcessDeactivationChain()
    {
        if (deactivationChain != null)
        {
            for (int i = 0; i < deactivationChain.Length; ++i)
                deactivationChain[i].Deactivate();
        }
    }

    /// <summary>
    /// For every object that this interaction must interact with, calls the
    /// function that interacts with the objects
    /// </summary>
    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }

    /// <summary>
    /// Does the entire interaction
    /// Triggers the corresponding animation and audio
    /// Calls the functions that activate, deactivate and interact with chained
    /// objects.
    /// Changes interaction text that will be displayed for the next interaction
    /// Loads new scene if the interactive changes the player scene
    /// </summary>
    public void Interact()
    {

        if (_anim != null)
        {
            _anim.SetTrigger("Interact");
        }


        if(interactionAudio != null && interactionAudioClips != null)
        {
            interactionAudio.PlayOneShot(interactionAudioClips[audioAux]);
            audioAux += 1;
        }

        if (interactionAudioClips != null)
        {
            if (audioAux == interactionAudioClips.Length)
            {
                audioAux = 0;
            }
        }

        if (isActive)
        {
            ProcessDeactivationChain();
            ProcessActivationChain();
            ProcessInteractionChain();

            numberOfUses += 1;
        }
    }
}
