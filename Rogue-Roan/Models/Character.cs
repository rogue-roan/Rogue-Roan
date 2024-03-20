﻿using Rogue_Roan.Enums;
using Rogue_Roan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models
{
    public abstract class Character //abstract : ne peut pas être instanciée directement.
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">le nom du personnage</param>
        /// <param name="endRaceBonus">son bonus racial d'endurance</param>
        /// <param name="strRaceBonus">son bonus racial de force</param>
        /// <param name="agiRaceBonus">son bonus racial d'agilité</param>
        /// <param name="luckRaceBonus">son bonus racial de chance</param>
        public Character(string race, string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus, int luckRaceBonus)
        {
            Name = name;
            Race = race;
            Dice dice = new Dice(1, 6); // dé utilisé pour la création de personnage
            EndRaceBonus = endRaceBonus;
            StrRaceBonus = strRaceBonus;
            AgiRaceBonus = agiRaceBonus;
            LuckRaceBonus = luckRaceBonus;
            _strenght = dice.BestOf(4, 3);
            _endurance = dice.BestOf(4, 3);
            _agility = dice.BestOf(4, 3);
            _luck = dice.BestOf(4, 3);
            PV = 10 + Modifiers.CalculateModifier(Endurance);
        }

        // positionnement du personnage
        public int PosX { get; set; }
        public int PosY { get; set; }

        // infos diverses
        public string Name { get; set; }
        public string Race { get; set; }

        // Force
        private int _strenght;
        public int Strenght
        {
            get
            {
                return _strenght + StrRaceBonus;
            }
        }
        public int StrRaceBonus { get; set; }

        // Endurance
        private int _endurance;
        public int Endurance
        {
            get
            {
                return _endurance + EndRaceBonus;
            }
        }
        public int EndRaceBonus { get; set; }

        // Agilité
        private int _agility;
        public int Agility
        {
            get
            {
                return _agility + AgiRaceBonus;
            }
        }
        public int AgiRaceBonus { get; set; }

        // Chance
        private int _luck; 
        public int Luck  
        {
            get
            {
                return _luck + LuckRaceBonus;
            }
        }
        public int LuckRaceBonus { get; set; }

        // points de vie
        private int _pv;
        public int PV
        {
            get
            {
                return _pv;
            }
            set
            {
                if (value < 0)
                {
                    _pv = 0;
                }
                else
                {
                    _pv = value;
                }
            }
        }

        // vérification de vie / mort
        public bool IsDead
        {
            get
            {
                return PV <= 0; //renvoie vrai si les PV sont <0 
            }
        }

        // l'équipement
        public Dictionary<Items, int> Equipment { get; set; } = new Dictionary<Items, int>();

        /// <summary>
        /// la méthode qui sert à frapper
        /// </summary>
        /// <param name="target">la cible frappée</param>
        public void Hits(Character target)
        {
            // on aura besoin de 1D pour toucher et 1D pour les dégâts
            Dice diceToHit = new Dice(1, 20);
            Dice diceForDamages = new Dice(1, 6);

            // le personnage fait son attaque : 1D20 + modificateur d'agilité
            int hit = diceToHit.Throw() + Modifiers.CalculateModifier(Agility);
            int valueToHitTarget = 10 + Modifiers.CalculateModifier(target.Agility);
            Console.WriteLine($"{Name} frappe {target.Name} et fait {hit}");

            // s'il fait >= à 10+bonus agi adverse il touche
            if (hit >= valueToHitTarget)
            {
                // dégâts = 1d6+modificateur de force
                int damageThrow = diceForDamages.Throw() + Modifiers.CalculateModifier(Strenght);
                // les dégâts sont au minimum égaux à 1
                int damages = damageThrow < 1 ? 1 : damageThrow;
                Console.WriteLine($"{Name} touche {target.Name} et fait {damages} points de dégâts");
                target.PV -= damages;
            }
            else
            {
                Console.WriteLine($"ce n'est pas suffisant pour toucher {target.Name}");
            }
        }

        // override de Tostring pour qu'il affiche le texte lorsque personnage.ToString();
        public override string ToString()
        {
            return $"{Name} - Endu : {Endurance}, Force : {Strenght}, Agilite : {Agility}, Chance : {Luck}, Pv : {PV}";
        }
    }
}
