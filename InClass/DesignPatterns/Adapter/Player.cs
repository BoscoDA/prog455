using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Player : Character
    {
        private string playerClass;

        //Has access to the "database"
        private InfoBank infoBank;

        //constructor
        public Player(string playerClass)
        {
            this.playerClass = playerClass;
            infoBank = new InfoBank();
        }

        public override string Info()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Player class : {playerClass}{Environment.NewLine}");
            stringBuilder.Append($"{playerClass} HP => { infoBank.GetHP(playerClass)}{Environment.NewLine}");
            stringBuilder.Append($"{playerClass} MP => { infoBank.GetMP(playerClass)}{Environment.NewLine}");
            stringBuilder.Append($"{playerClass} Stamind => { infoBank.GetStamina(playerClass)}{Environment.NewLine}");

            return stringBuilder.ToString();


        }
    }
}
