using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseShared;
using SamEngine;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FollowMouse
{
    public class ModEntryPoint : IMod
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        // Gets called automatically, passes in a class that contains pointers to
        // useful functions we need to interface with the goose.
        void IMod.Init()
        {
            // Subscribe to whatever events we want
            InjectionPoints.PostTickEvent += PostTick;
            
        }

        
        public void PostTick(GooseEntity goose)
        {

            if (goose.currentTask==0) {
                if (GetAsyncKeyState(Keys.Up) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x, goose.position.y -1);


                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);
                }
                if (GetAsyncKeyState(Keys.Down) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x, goose.position.y +1);
                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);

                }
                if (GetAsyncKeyState(Keys.Left) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x -1, goose.position.y);
                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);
                }
                if (GetAsyncKeyState(Keys.Right) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x +1, goose.position.y);
                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);
                }
            }
            // Do whatever you want here.
            if (API.Goose.isGooseAtTarget(goose, 1))
            {
                if (GetAsyncKeyState(Keys.Up) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x, goose.position.y -10);


                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);
                }
                if (GetAsyncKeyState(Keys.Down) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x, goose.position.y +10);
                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);

                }
                if (GetAsyncKeyState(Keys.Left) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x -10, goose.position.y);
                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);
                }
                if (GetAsyncKeyState(Keys.Right) != 0)
                {
                    goose.targetPos = new Vector2(goose.position.x +10, goose.position.y);
                    API.Goose.setCurrentTaskByID(goose, "ArrowControl", false);
                }
                
            }
            
        }
    }
}
