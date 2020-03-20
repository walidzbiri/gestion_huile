using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3
{
    class Huile
    {
        public string nom { get; set; }
        public int vf { get; set; }
        public int vc { get; set; }
        public double prix { get; set; }
        public int stock { get; set; }
        public string petrolier { get; set; }

        public Huile()
        {
            nom = null;petrolier = null;
            vf = 0;vc = 0;prix = 0;stock = 0;

        }

        public Huile(string nom, int vf, int vc, double prix, int stock, string petrolier)
        {
            this.nom = nom;
            this.vf = vf;
            this.vc = vc;
            this.prix = prix;
            this.stock = stock;
            this.petrolier = petrolier;
        }
        public override string ToString()
        {
            return nom + "\t" + vf + "\t" + vc + "\t" + prix + "\t" + stock + "\t" + petrolier;
        }
    }
}
