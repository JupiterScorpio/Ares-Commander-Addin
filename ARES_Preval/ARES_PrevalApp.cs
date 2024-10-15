using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Teigha.Ribbon;
using Teigha.Runtime;
using Teigha.Windows;

namespace ARES_Preval
{
    internal class ARES_PrevalApp : IExtensionApplication
    {
        /* Plugin initialization and cleanup stuff */
        #region IExtensionApplication overrides
        /*
         * If your module need initialization stuff the IExtensionApplication.Initialize  
         * is the correct place to do it here
         */
        void IExtensionApplication.Initialize()
        {
            /* Create your UI here if required, This UI will be available once you load this plugin. */
            CreateUI();
        }
        /*
         * Write cleanup stuff here
         */
        void IExtensionApplication.Terminate()
        {
        }
        #endregion
        /* Optional stuff below to create Ribbon UI */
        #region Optional Code for UI Creation
        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
        void CreateUI()
        {

            RibbonCommandButton btn = new RibbonCommandButton();
            btn.Text = "ARES_Preval Sample Command";
            btn.CommandHandler = new ARESPluginCommandHandler();
            btn.CommandParameter = "CSCmd";
            btn.ShowText = true;

            BitmapImage bitmapImage = Convert(Properties.Resources.Image1);
            btn.LargeImage = bitmapImage;
            btn.Image = bitmapImage;

            RibbonPanelSource ps = new RibbonPanelSource();
            ps.Title = "ARES_Preval Commands";
            ps.Items.Add(btn);

            RibbonPanel panel = new RibbonPanel();
            panel.Source = ps;


            RibbonTab tab = new RibbonTab();
            tab.Name = "ARES_PrevalTab";
            tab.Title = "ARES_Preval Tab";
            tab.Panels.Add(panel);

            ComponentManager.Ribbon.Tabs.Add(tab);
            tab.IsActive = true;
        }
    }

    internal class ARESPluginCommandHandler : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RibbonCommandButton btn = parameter as RibbonCommandButton;
            string sCommand = btn.CommandParameter as string;
            Teigha.ApplicationServices.Application.DocumentManager.MdiActiveDocument.SendStringToExecute(sCommand, false, false, true);
        }
    }
    #endregion
}
