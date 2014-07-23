using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
	public enum AlertType 
    {
		RIGHT, LEFT, STOP, NO_GUI
	}

    [RequireComponent(typeof(OneWayTrigger))]
    [AddComponentMenu("Triggered Audio")]
    public class TriggeredAudio : MonoBehaviour
    {
        public AudioSource audioSrc;
		public AlertType alertType;
		public float timeToDisplay;

        private OneWayTrigger trigger;
		private OneWayTrigger endTrigger;
		private bool triggered = false;
		private float timeSinceTrigger = 0f;

        void Start()
        {
            trigger = GetComponent<OneWayTrigger>();
            trigger.Triggered += () =>
            {
				triggered = true;
				timeSinceTrigger = 0f;
                audioSrc.Play();
            };
        }

		void Update()
        {
			if (triggered) 
            {
				timeSinceTrigger += Time.deltaTime;
				if (timeSinceTrigger > timeToDisplay)
                {
					triggered = false;
					timeSinceTrigger = 0f;
				}
			}
		}

		void OnGUI() 
        {
			if (triggered) 
            {
				switch (alertType)
                {
					case AlertType.LEFT:
						drawLeftArrow();
						break;
					case AlertType.RIGHT:
						drawRightArrow();
						break;
					case AlertType.STOP:
						drawStopSign();
						break;
				}
			}
		}

		private void drawLeftArrow() 
        {
			Drawing.DrawLine(new Vector2(70, 60), new Vector2(140, 60), Color.white, 5);
			Drawing.DrawLine(new Vector2(70, 60), new Vector2(90, 45), Color.white, 5);
			Drawing.DrawLine(new Vector2(70, 60), new Vector2(90, 75), Color.white, 5);
		}

		private void drawRightArrow() 
        {
			Drawing.DrawLine(new Vector2(70, 60), new Vector2(140, 60), Color.white, 5);
			Drawing.DrawLine(new Vector2(140, 60), new Vector2(120, 45), Color.white, 5);
			Drawing.DrawLine(new Vector2(140, 60), new Vector2(120, 75), Color.white, 5);
		}

		private void drawStopSign()
        {
			Drawing.DrawLine(new Vector2(120, 40), new Vector2(100, 40), Color.red, 5);
			Drawing.DrawLine(new Vector2(100, 40), new Vector2(80, 60), Color.red, 5);
			Drawing.DrawLine(new Vector2(80, 60), new Vector2(80, 80), Color.red, 5);
			Drawing.DrawLine(new Vector2(80, 80), new Vector2(100, 100), Color.red, 5);
			Drawing.DrawLine(new Vector2(100, 100), new Vector2(120, 100), Color.red, 5);
			Drawing.DrawLine(new Vector2(120, 100), new Vector2(140, 80), Color.red, 5);
			Drawing.DrawLine(new Vector2(140, 80), new Vector2(140, 60), Color.red, 5);
			Drawing.DrawLine(new Vector2(140, 60), new Vector2(120, 40), Color.red, 5);
		}
	}
}
