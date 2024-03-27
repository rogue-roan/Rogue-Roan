using Rogue_Roan.Enums;
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

        // revoir la generation de personnage, on doit mettre la valeur, elle n'est aléatoire que si la valeur n'est pas mise
        // starts Now


        /// <summary>
        /// creation du personnage si je donne les caracs en dur
        /// </summary>
        /// <param name="race">la race du personnage</param>
        /// <param name="name">le nom du personnage</param>
        /// <param name="endurance">son endurance</param>
        /// <param name="strength">sa force</param>
        /// <param name="agility">son agilité</param>
            public Character(string race, string name, int endRaceBonus = 0, int strRaceBonus = 0, int agiRaceBonus = 0, int endurance = 0, int strength = 0, int agility = 0)
        {
            Name = name;
            Race = race;

            if (endurance != 0 && strength != 0 && agility != 0)
            {
                // Création du personnage avec des valeurs spécifiées
                _strength = strength;
                _endurance = endurance;
                _agility = agility;
            }
            else
            {
                // Création du personnage avec des valeurs basées sur des jets de dés
                Dice dice = new Dice(1, 6); // dé utilisé pour la création de personnage
                EndRaceBonus = endRaceBonus;
                StrRaceBonus = strRaceBonus;
                AgiRaceBonus = agiRaceBonus;

                int strengthThrow = dice.BestOf(4, 3);
                int enduranceThrow = dice.BestOf(4, 3);
                int agilityThrow = dice.BestOf(4, 3);

                _strength = strengthThrow + strRaceBonus;
                _endurance = enduranceThrow + endRaceBonus;
                _agility = agilityThrow + agiRaceBonus;
            }

            HP = 10 + Modifiers.CalculateModifier(Endurance);
        }







        // positionnement du personnage
        public int PosX { get; set; }
        public int PosY { get; set; }

        // infos diverses
        public string Name { get; set; }
        public string Race { get; set; }

        // valeur minimale
        private int minValue = 3;


        // Force
        private int _strength;
        public int Strength 
        {
            get
            {
                return _strength;
            }
            set
            {
                if (value < minValue) { value = minValue; }
            }
        }
        public int StrRaceBonus { get; set; }

        // Endurance
        private int _endurance;
        public int Endurance
        {
            get
            {
                return _endurance;
            }
            set
            {
                if (value < minValue) { value = minValue; }
            }
        }
        public int EndRaceBonus { get; set; }

        // Agilité
        private int _agility;
        public int Agility
        {
            get
            {
                return _agility;
            }
            set
            {
                if (value < minValue) { value = minValue; }
            }
        }
        public int AgiRaceBonus { get; set; }

        

        // points de vie
        private int _hp;
        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value < 0)
                {
                    _hp = 0;
                }
                else
                {
                    _hp = value;
                }
            }
        }

        // vérification de vie / mort
        public bool IsDead
        {
            get
            {
                return HP <= 0; //renvoie vrai si les PV sont <0 
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
                int damageThrow = diceForDamages.Throw() + Modifiers.CalculateModifier(Strength);
                // les dégâts sont au minimum égaux à 1
                int damages = damageThrow < 1 ? 1 : damageThrow;
                Console.WriteLine($"{Name} touche {target.Name} et fait {damages} points de dégâts");
                target.HP -= damages;
            }
            else
            {
                Console.WriteLine($"ce n'est pas suffisant pour toucher {target.Name}");
            }
        }

        // override de Tostring pour qu'il affiche le texte lorsque personnage.ToString();
        public override string ToString()
        {
            return $"{Name} - Pv : {HP}, Endu : {Endurance}, Force : {Strength}, Agilite : {Agility}";
        }
    }
}
