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
            // Do whatever you want here.
            if (GetAsyncKeyState(Keys.Up) != 0) {
                goose.targetPos=new Vector2(goose.position.x, goose.position.y- goose.currentSpeed/10);

                API.Goose.setCurrentTaskByID(goose, "ArrowControl", true);
            }
            if (GetAsyncKeyState(Keys.Down) != 0)
            {
                goose.targetPos = new Vector2(goose.position.x, goose.position.y+ goose.currentSpeed/10);
                API.Goose.setCurrentTaskByID(goose, "ArrowControl", true);
                
            }
            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                goose.targetPos = new Vector2(goose.position.x - goose.currentSpeed/10 , goose.position.y);
                API.Goose.setCurrentTaskByID(goose, "ArrowControl", true);
            }
            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                goose.targetPos = new Vector2(goose.position.x + goose.currentSpeed/10, goose.position.y);
                API.Goose.setCurrentTaskByID(goose, "ArrowControl", true);
            }
        }
    }
}
