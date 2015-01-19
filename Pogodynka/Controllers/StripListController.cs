using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;

namespace Pogodynka.Controllers
{
    public class StripListController : Controller
    {
        List<ToolStripMenuItem> MenuItems =new List<ToolStripMenuItem>();
        ToolStripMenuItem ParentMenuItem = new ToolStripMenuItem();

        public StripListController(View view, Model model)
        {
            this.ViewUsed = (TemperatureChart)view;
            this.ModdelUsed = (RssTemp)model;
            model.addSubscriber(view);
        }

        public void BindToMenuAndInit(ToolStripMenuItem menuPassed)
        {
            this.ParentMenuItem = menuPassed;
            
            foreach (City city in this.ModdelUsed.getAvailableCities())
            {
                MenuItemInit(city.cityName, ParentMenuItem);
            }
        }

        public ToolStripMenuItem MenuItemInit(string nameDisplayed, 
               ToolStripMenuItem ParentMenuItem)
        {
            ToolStripMenuItem cityMenuItem = new ToolStripMenuItem(nameDisplayed, null, On_City_Clicked);
            ParentMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cityMenuItem });
            return cityMenuItem;
        }

        private void On_City_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem ItemClicked = (ToolStripMenuItem)sender;
            string seriesName = ItemClicked.Text;

            if (!ViewUsed.isSeriesDisplayed(seriesName))
            {
                executeCommand(ItemClicked.Text.ToLower() + "ADD" );
            }
            else
            {
                executeCommand(ItemClicked.Text.ToLower() + "DEL");
            }

            ItemClicked.Checked = ViewUsed.isSeriesDisplayed(seriesName);
        }

    }
}


