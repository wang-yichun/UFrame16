using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.MVVM.Services;
using uFrame.MVVM.Bindings;
using uFrame.Serialization;
using UniRx;
using UnityEngine;

namespace uFrame.ExampleProject
{
	/*
     * This view serves as a base class for all the SubScreen views
     * It handles screen activation/deactivation.
     * It also handles binding for Close command. You can configure it using the inspector.
     */
	public class SubScreenView : SubScreenViewBase
	{

		public GameObject ScreenUIContainer;
		public CanvasGroup ScreenUIContainerCanvasGroup;

		public void Awake ()
		{
			if (ScreenUIContainer != null && ScreenUIContainerCanvasGroup == null)
				ScreenUIContainerCanvasGroup = ScreenUIContainer.GetComponent<CanvasGroup> (); //Try to grab canvas group
			if (ScreenUIContainerCanvasGroup == null)
				ScreenUIContainerCanvasGroup = ScreenUIContainer.AddComponent<CanvasGroup> (); //If it does not exist, create one.
			
			//Coalesc operator (??) does not work here due to weird unity behaviour
			
		}

		protected override void InitializeViewModel (uFrame.MVVM.ViewModel model)
		{
			base.InitializeViewModel (model);
		}

		public override void Bind ()
		{
			base.Bind ();
		}

		public override void IsActiveChanged (Boolean active)
		{
			/*
             * Always make sure, that you cache components used in the binding handlers BEFORE you actually bind.
             * This is important, since when Binding to the viewmodel, Handlers are invoked immidiately
             * with the current values, to ensure that view state is consistant.
             * For example, you can do this in Awake or in KernelLoading/KernelLoaded.
             * However, in this example we simply use public property to get a reference to ScreenUIContainer.
             * So we do not have to cache anything.
             */
			
			var targetAlpha = active ? 1f : 0f; //fade to 1 if screen is active, else fade to 0
			var time = 0.2f; //how fast to fade
			var delay = active ? time : 0; //delay if screen is active, to let other screen deactivate
			
			if (active) {
				//activate container game object
				ScreenUIContainer.gameObject.SetActive (true);
				//set alpha to zero
				ScreenUIContainerCanvasGroup.alpha = 0;
				//start fading
				FadeAlpha (ScreenUIContainerCanvasGroup, targetAlpha, time, null, delay);
			} else {
				//fade out
				FadeAlpha (ScreenUIContainerCanvasGroup, targetAlpha, time, () =>
				{
					//on complete, maintain consistant active status of the gameObject:
					//This prevents glitches, if IsActive property changes too fast
					ScreenUIContainer.gameObject.SetActive (SubScreen.IsActive);
				}, delay);
			}
//			ScreenUIContainer.gameObject.SetActive (active);
		}

		/**
         * target - target CanvasGroup to fade
         * alpha - target alpha to fade to
         * time - time take to fade to target
         * onComplete (optional) - invoked after fading is complete
         * delay (optional) - delay before start fading.
         */
		void FadeAlpha (CanvasGroup target, float alpha, float time, Action onComplete = null, float delay = 0.0f)
		{
			//Stop any fading before starting new one
			StopCoroutine ("Fade");
			//Invoke coroutine
			StartCoroutine (Fade (target, alpha, time, onComplete, delay));
		}

		IEnumerator Fade (CanvasGroup target, float alpha, float time, Action onComplete = null, float delay = 0.0f)
		{
			
			target.interactable = false;
			
			//Wait for delay
			if (delay > 0.0f)
				yield return new WaitForSeconds (delay);
			//Start time
			var start = Time.time;
			while (Math.Abs(target.alpha - alpha) > 0.01f) {
				//Time passed from start
				var elapsed = Time.time - start;
				//normalized time from 0..1
				var normalisedTime = Mathf.Clamp ((elapsed / time) * Time.deltaTime, 0, 1);
				//assign interpolated value
				target.alpha = Mathf.Lerp (target.alpha, alpha, normalisedTime);
				yield return null;
			}
			//invoke on complete if given
			if (onComplete != null)
				onComplete ();
			
			target.interactable = true;
		}

	}
}