using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pogodynka
{
    public abstract class Controller
    {
        public RssTemp ModdelUsed;
        protected TemperatureChart ViewUsed;

        private int COMMAND_NAME = 0;
        private int COMMAND_ARGUMENT = 1;

        protected void executeCommand(string command)
        {
            string[] CommandStructure = processCommand(command);

            switch (CommandStructure[COMMAND_NAME])
            {
                case "ADD":
                    ViewUsed.addCityToSub(CommandStructure[COMMAND_ARGUMENT]);
                    ModdelUsed.PropertyChanged();
                    break;

                case "DEL":
                    ViewUsed.delCityFromSub(CommandStructure[COMMAND_ARGUMENT]);
                    ModdelUsed.PropertyChanged();
                    break;
            }
        }

        private string[] processCommand(string command)
        {
            string[] CommandStruct = new string[2];
            foreach (char letterOfCommand in command)
            {
                if (System.Char.IsUpper(letterOfCommand))
                {
                    CommandStruct[COMMAND_NAME] += letterOfCommand;
                }
                else
                {
                    CommandStruct[COMMAND_ARGUMENT] += letterOfCommand;
                }
            }
            CommandStruct[COMMAND_ARGUMENT] = TextTools.StartWithCapital(CommandStruct[COMMAND_ARGUMENT]);
            return CommandStruct;
        }

    }
}
