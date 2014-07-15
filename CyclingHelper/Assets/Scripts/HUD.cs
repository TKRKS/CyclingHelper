using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts 
{
    public enum Alerts
    {
        BetterRouteAhead,
        TwoWayStop,
        FourWayStop
    }

	public class HUD : MonoBehaviour
    {
        private readonly Rect titleRect = new Rect(10, 10, 200, 120);

        private List<Alerts> alerts;

        void Start()
        {
            alerts = new List<Alerts>();
        }

		void OnGUI()
        {
			Vector3 pos = gameObject.transform.position;
            GUI.Box(titleRect, "CyclingHelper");
		}

        public void RaiseAlert(Alerts alert)
        {
            alerts.Add(alert);
        }
	}
}

