﻿using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace HRM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new XtraForm2());
        }
    }
}
