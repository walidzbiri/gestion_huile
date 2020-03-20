using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3
{
    class Program
    {
        List<Huile> T1 = new List<Huile>();
         static void Main(string[] args)
        {
            Program p = new Program();
            int flag = 1;
            while (flag == 1)
            {
                p.menu(flag);
            }
        }
        void saisie(string nom, int vf, int vc, double prix, int stock, string petrolier)
        {
            T1.Add(new Huile(nom, vf, vc, prix, stock, petrolier));
        }
        void liste()
        {
            foreach(Huile h in T1)
            {
                Console.WriteLine(h.ToString());
            }
        }
        List<Huile> trier()
        {
           return T1.OrderBy(o => o.stock).ToList();
        }
        double valeur_total(string fournisseur)
        {
            double total = 0;
            foreach(Huile h in T1)
            {
                if (h.petrolier.Equals(fournisseur))
                {
                    total += h.prix * h.stock;
                }
            }
            return total;
        }
        List<Huile> rupture_stock()
        {
            List<Huile> T2 = new List<Huile>();
            foreach (Huile h in T1)
            {
                if (h.stock == 0)
                {
                    T2.Add(h);
                }
            }
            return T2;
        }
        List<Huile> deStockage()
        {
            List<Huile> T3 = new List<Huile>();
            foreach (Huile h in T1)
            {
                if (h.stock <= 5)
                {
                    h.prix *= 0.6;
                    T3.Add(h);
                }
                else
                {
                    T3.Add(h);
                }
            }
            return T3;
        }
        void maxVC()
        {
            foreach (Huile h in T1)
            {
                if (h.vc == 50)
                {
                    Console.WriteLine(h.ToString());
                }
            }
        }
        void maxVF()
        {
            foreach (Huile h in T1)
            {
                if (h.vf == 20)
                {
                    Console.WriteLine(h.ToString());
                }
            }
        }
        void viscosite_max()
        {
            foreach (Huile h in T1)
            {
                if (h.vf == 20 && h.vc==50)
                {
                    Console.WriteLine(h.petrolier);
                }
            }
        }
        void supprimer_viscosite(int vc,int vf)
        {
            foreach (Huile h in T1)
            {
                if (h.vf == vf && h.vc == vc)
                {
                    T1.Remove(h);
                }
            }
        }
        void sauvegarder_fichier()
        {
            // j'ai utilisé le package json dot net telechargé via nuget
            Console.WriteLine("Consulter \\bin\\Debug");
            File.WriteAllText("myobjects.json", JsonConvert.SerializeObject(T1));
        }
        void restaurer_a_partir_du_fichier()
        {
            string json = File.ReadAllText("myobjects.json");
            List<Huile> T1 = JsonConvert.DeserializeObject<List<Huile>>(json);
        }
        void menu(int flag)
        {
            string choix;
            Console.WriteLine("===========Menu===========");
            Console.WriteLine("1- Saisir un objet");
            Console.WriteLine("2- Lister les objets");
            Console.WriteLine("3- Trier par stock");
            Console.WriteLine("4- Valeur Total");
            Console.WriteLine("5- Rupture stock");
            Console.WriteLine("6- Destockage");
            Console.WriteLine("7- MaxVC");
            Console.WriteLine("8- MaxVF");
            Console.WriteLine("9- Viscosité maximale");
            Console.WriteLine("10- Supprimer Viscosité");
            Console.WriteLine("11- Sauvegarder dans un fichier T1");
            Console.WriteLine("12- Restaurer T1 à partir d'un fichier");
            Console.WriteLine("13- Quitter");
            Console.Write("=====> Votre Choix: ");
            choix=Console.ReadLine();
            switch (choix)
            {
                case "1":
                    Console.Write("Nom: ");string nom=Console.ReadLine();
                    Console.Write("VF: ");int vf=Int16.Parse(Console.ReadLine());
                    Console.Write("VC: ");int vc= Int16.Parse(Console.ReadLine());
                    Console.Write("Prix: ");double prix=double.Parse(Console.ReadLine());
                    Console.Write("Stock: ");int stock= Int16.Parse(Console.ReadLine());
                    Console.Write("Pétrolier: ");string petrolier= Console.ReadLine();
                    saisie(nom, vf, vc, prix, stock, petrolier);
                    break;
                case "2":
                    Console.WriteLine("Liste des Huiles");
                    liste();
                    break;
                case "3":
                    Console.WriteLine("Tri effectué");
                    T1=trier();
                    break;
                case "4":
                    Console.Write("Entrez le fournisseur: ");
                    string fournisseur = Console.ReadLine();
                    Console.WriteLine("Valeur Total "+valeur_total(fournisseur));
                    break;
                case "5":
                    Console.Write("Rupture de stock T2: ");
                    List<Huile> T2;
                    T2 = rupture_stock();
                    foreach (Huile h in T2)
                    {
                        Console.WriteLine(h.ToString());
                    }
                    break;
                case "6":
                    Console.Write("Destockage T3: ");
                    List<Huile> T3;
                    T3 = deStockage();
                    foreach (Huile h in T3)
                    {
                        Console.WriteLine(h.ToString());
                    }
                    break;
                case "7":
                    Console.Write("Max VC: ");
                    maxVC();
                    break;
                case "8":
                    Console.Write("Max VF: ");
                    maxVF();
                    break;
                case "9":
                    Console.Write("Viscosité max: ");
                    viscosite_max();
                    break;
                case "10":
                    Console.Write("Entrez VC: "); vc = Int16.Parse(Console.ReadLine());
                    Console.Write("Entrez VF: "); vf = Int16.Parse(Console.ReadLine());
                    supprimer_viscosite(vc, vf);
                    break;
                case "11":
                    Console.WriteLine("Sauvegarde dans myobjects.json");
                    sauvegarder_fichier();
                    break;
                case "12":
                    Console.WriteLine("Restaurer à partir de myobjects.json");
                    restaurer_a_partir_du_fichier();
                    break;
                case "13":
                    flag = 0;
                    Console.WriteLine("Au revoir");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Erreur de choix try again");
                    menu(1);
                    break;
            }
        }
    }
}
