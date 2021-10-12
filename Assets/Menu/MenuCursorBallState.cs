using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class MenuCursorBallState : MenuBaseState
    {
        public override void EnterState(MenuStateManager menu, string option)
        {
            menu.menu_options["CursorButton"] = new[] {4, 5};
            menu.menu_options["rPSMButton"] = new[] {6};
            menu.menu_options["vPSMButton"] = new[] {7};
            menu.menu_options["FollowButton"] = new[] {8, 9};
        }

        public override void UpdateState(MenuStateManager menu, string option)
        {
            //Debug.Log("Menu " + menu.name + ": in Spectator State.");
            //Debug.Log("The Menu should be visible");

            expandMenu(menu, "main_options");

            if (option == "none")
            {
                //Debug.Log("I have exited my collision");
                shrinkMenu(menu, option);
            }
            else
            {
                Debug.Log(option);
                expandMenu(menu, option);
            }
            
        }

        private void expandMenu(MenuStateManager menu, string option)
        {
            Debug.Log(menu.menu_options[option].Length);
            for (int i = 0; i < menu.menu_options[option].Length; i++)
            {
                Debug.Log("i:" + i + " is " + menu.gameObject.transform.GetChild(i).name);
                menu.gameObject.transform.GetChild(menu.menu_options[option][i]).gameObject.SetActive(true);
            }
        }

        private void shrinkMenu(MenuStateManager menu, string option)
        {
            for (int i = 0; i < menu.menu_options[option].Length; i++)
            {
                //Debug.Log("i:" + i + " is " + menu.gameObject.transform.GetChild(i).name);
                menu.gameObject.transform.GetChild(menu.menu_options[option][i]).gameObject.SetActive(false);
            }
        }
    }
}
        