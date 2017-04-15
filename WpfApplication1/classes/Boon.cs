using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzPzRPG.classes
{
    public class Boon
    {
        public enum Target { Health, Resource, Speed, None }

        public string Name { get { return NameActual; } }
        /// <summary>
        /// Additional descriptive text to describe this boon.
        /// </summary>
        public string FlavorText { get { return Description; } }
        /// <summary>
        /// Which attribute am I modifying?
        /// </summary>
        public Target TargetAttribute { get { return EffectedAttribute; } }
        /// <summary>
        /// How much am I effecting the TargetAttribute by? (Can be % or direct)
        /// </summary>
        public double Value { get { return DeltaValue; } }
        /// <summary>
        /// Should my Value be considered as a percentage value of the TargetAttribute?
        /// </summary>
        public bool IsPercentage { get { return DirectIncrease; } }
        /// <summary>
        /// Am I a helpful boon, or a hurtful one?
        /// </summary>
        public bool IsNegative { get { return IsDebuff; } }
        /// <summary>
        /// Am I past my expiration date? If exp. date is null, will always return false.
        /// </summary>
        public bool Expired
        {
            get
            {
                if (Expires == null)
                {
                    return false;
                }
                else
                {
                    if (DateTime.Now > Expires)
                        Console.WriteLine($"{Name} has expired!");
                    return DateTime.Now > Expires;
                }
            }
        }

        #region "Internal Private Variable Declaration"

        private string NameActual = "";
        private string Description = "";
        private double DeltaValue = 0.0;
        private bool DirectIncrease = false;
        private Target EffectedAttribute = Target.None;
        private Nullable<DateTime> Expires = null;
        private bool IsDebuff = false;

        #endregion

        #region "Constructors"

        public Boon()
        {

        }
        public Boon(string name, string descr = "")
        {
            NameActual = name;
            Description = descr;
        }
        public Boon(string name, string descr, Target attr, double val, bool percentage = false, bool debuff = false, Nullable<DateTime> expiration = null)
        {
            NameActual = name;
            EffectedAttribute = attr;
            DeltaValue = val;
            DirectIncrease = percentage;
            Expires = expiration;
            IsDebuff = debuff;
        }

        #endregion

    }
}
