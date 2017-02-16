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
        [SerializeField]
        private bool usingKeyboard = true;
        [SerializeField]
        private bool usingArrows = true;

        private float horizontal;
        private float vertical;
        private bool shoot;
        
        private PlayerUnit player;

        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<PlayerUnits>()._players[Data.PlayerData.PlayerId.Player1].GetComponent<PlayerUnit>();
        }

        // Update is called once per frame
        void Update()
        {
            if(usingKeyboard) {
                if(usingArrows) {
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                }
                else
                {
                    horizontal = Input.GetAxis("Horizontal3");
                    vertical = Input.GetAxis("Vertical3");
                }
                shoot = Input.GetButton("Shoot");
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal2");
                vertical = Input.GetAxis("Vertical2");
                shoot = Input.GetButton("Shoot2");
            }

            Vector3 input = new Vector3(horizontal, 0, vertical);

            player.Mover.MoveToDirection(input);
            
            if (shoot)
            {
                player.Weapons.Shoot(player.ProjectileLayer);
            }
        }
    }
}