using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzPzRPG
{


    public class DummyMain {
        public static void Dummy() {
            classes.Character c = new classes.Character("Chosimba");
            Strength str = new Strength(c, 10);
            bool unitTest = str.meetsMinimum(15); // false
        }
    }

    public class Strength : IStatistic
    {
        //Internals
        private string _Name = "Strength";
        private double _Value = 0;
        private classes.Character _Owner;

        // IStatistic implementation
        public string name { get { return _Name; } }
        public double value { get { return _Value; } }
        public classes.Character owner { get { return _Owner; } }

        public bool meetsMinimum(double valueToCheck) {
            return _Value >= valueToCheck;
        }

        // IAttribute implementation
        public double buffvalue {
            get {
                return 0.0;
            }
        }

        // Constructor(s)
        public Strength(classes.Character owner, double initValue) {
            _Owner = owner;
            _Value = initValue;
        }
    }


    interface IAttribute : IStatistic {
        double buffvalue { get; }
    }
    interface IStatistic
    {
        classes.Character owner { get; }
        string name { get; }
        double value { get; }
        bool meetsMinimum(double val);
    }
}
