
using UnityEngine;

namespace Menu
{
    public class MenuCursorLaserState : MenuBaseState
    {
        private int[] display_children;
        public override void EnterState(MenuStateManager menu, string option)
        {
            display_children = new[]
            {
                0,
                1,
                2,
                3,
                4,
                5,
                7,
                8,
                9,
                10
            };
        }

        public override void UpdateState(MenuStateManager menu, string option)
        {
            //Debug.Log("Menu " + menu.name + ": in Spectator State.");
            //Debug.Log("The Menu should be visible");
            for (int i = 0; i < display_children.Length; i++)
            {
                Debug.Log("i:" + i + " is " + menu.gameObject.transform.GetChild(i).name);
                menu.gameObject.transform.GetChild(display_children[i]).gameObject.SetActive(true);
            }
        }
    }
}