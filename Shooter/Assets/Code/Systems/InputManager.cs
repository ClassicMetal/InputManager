using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TAMKShooter.Utility;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class InputManager : MonoBehaviour
    {
        private PlayerUnit player;
        // Use this for initialization
        void Start()
        {
            
        }

        void Awake()
        {
            player = GetComponentInParent<Transform>().GetComponentInChildren<PlayerUnits>()._players[Data.PlayerData.PlayerId.Player1].GetComponent<PlayerUnit>();
        }

        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 input = new Vector3(horizontal, 0, vertical);

            player.Mover.MoveToDirection(input);

            bool shoot = Input.GetButton("Shoot");
            if (shoot)
            {
                player.Weapons.Shoot(player.ProjectileLayer);
            }
        }
    }
}