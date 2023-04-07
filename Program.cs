using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SretenProkopic
{
    //*************************************
    class Oruzje
    {
        private string regBroj;
        private int kalibar;

        //konstruktor
        public Oruzje(string regBroj, int kalibar)
        {
            if (regBroj == null)
                regBroj = "nema";
            else
                this.regBroj = regBroj;

            if (kalibar == 12 || kalibar == 16)
                this.kalibar = kalibar;
            else
                this.kalibar = 12;
        }

        //svojstva
        public string RegBroj
        {
            get { return regBroj; }
            set
            {
                if (value == null)
                    Console.WriteLine("Nispravan unos registarskog broja oruzja!");
                else
                    regBroj = value;
            }
        }
        public int Kalibar
        {
            get { return kalibar; }
            set
            {
                if (value != 12 && value != 16)
                    Console.WriteLine("Neispravan kalibar!");
                else
                    kalibar = value;
            }
        }
        //metode
        public void IspisO()
        {
            string o = regBroj + " " + kalibar;
            Console.WriteLine(o);
        }

    }
    //*************************************
    class Trofej
    {
        private string lovnaGodina;
        private string oznakaDivljaci;
        private int brojMarkice;

        //konstruktor
        public Trofej(string lovnaGodina, string oznakaDivljaci, int brojMarkice)
        {
            this.lovnaGodina = lovnaGodina;
            this.oznakaDivljaci = oznakaDivljaci;
            if (brojMarkice < 0 && brojMarkice > 500)
                this.brojMarkice = 1;
            else
                this.brojMarkice = brojMarkice;
        }

        //svojstva
        public string LovnaGodina
        {
            get { return lovnaGodina; }
        }

        public string OznakaDivljaci
        {
            get { return oznakaDivljaci; }
        }

        public int BrojMarkice
        {
            get { return brojMarkice; }
            set
            {
                if (value < 1 && value > 500)
                    Console.WriteLine("Neispravan unos broja markice");
                else
                    brojMarkice = value;
            }
        }
        //metode
        public void IspisT()
        {
            string t = lovnaGodina + " " + oznakaDivljaci + " " + brojMarkice;
            Console.WriteLine(t);
        }

    }
    //***************************************
    class Lovac
    {
        private string imePrezime;
        private int godiste;
        private bool aktivan;
        private List<Oruzje> listaOruzja;
        private List<Trofej> listaTrofeja;

        //konstruktori
        public Lovac(string imePrezime, int godiste)
        {
            this.imePrezime = imePrezime;
            if (godiste >= 1921 && godiste <= 2002)
                this.godiste = godiste;
            else
                this.godiste = 2002;
            this.aktivan = true;
            this.listaOruzja = new List<Oruzje>();
            this.listaTrofeja = new List<Trofej>();
        }

        //svojstva
        public string ImePrezime
        {
            get { return imePrezime; }
        }
        public int Godiste
        {
            get { return godiste; }
            set
            {
                if (value >= 1921 && value <= 2002)
                    godiste = value;
                else
                    Console.WriteLine("Neispravan unos godista!");
            }
        }
        public bool Aktivan
        {
            get { return aktivan; }
        }

        //metode
        public void DodajOruzje(Oruzje O)
        {
            listaOruzja.Add(O);
        }
        public void DodajTrofej(Trofej T)
        {
            listaTrofeja.Add(T);
        }
        public void BrojTrofeja()
        {
            int brT = 0;
            foreach (Trofej T in listaTrofeja)
                if (T.BrojMarkice != 1)  // poziva get svojstvo BrojMarkice jer zbog enkapsulacije ne moze da psitupi direktno brojMarkice
                    brT++;
            Console.WriteLine("Broj trofeja: " + brT);
        }
        public void BrojOruzja()
        {
            int brO = 0;
            foreach (Oruzje O in listaOruzja)
                if (O.RegBroj != "nema") // poziva get svojstvo RegBroj jer zbog enkapsulacije ne moze da pristupi direktno regBroj
                    brO++;
            Console.WriteLine("Broj Oruzja: " + brO);
        }

        public void IspisLovca()
        {
            Console.WriteLine("Lovac " + imePrezime + " rodjen: " + godiste + ". godine");
            Console.WriteLine("poseduje sledece oruzje:");
            foreach (Oruzje O in listaOruzja)
                O.IspisO();
            Console.WriteLine("Lovackom udruzenju doneo je sledece trofeje:");
            foreach (Trofej T in listaTrofeja)
                T.IspisT();
        }
    }
    //****************************************
    class VodjaGrupe : Lovac  //vodja grupe je lovac pa imamo nasledjivanje
    {
        private string loviste;
        private string zbornoMesto;

        //konstruktor
        public VodjaGrupe(string vdimePrezime,
                          int vdgodiste,
                          bool vdaktivan,
                          string vdloviste,
                          string vdzbornoMesto)

            : base(vdimePrezime, vdgodiste) // poziv konsruktora Lovac sa dva parametra 
        {
            loviste = vdloviste;
            zbornoMesto = vdzbornoMesto;
            vdaktivan = true;
        }

        //metode
        public void IspisVodjaGrupe()
        {
            Console.WriteLine("Vodja grupe za loviste " + loviste + " i zborno mesto " + zbornoMesto + " je:");
            base.IspisLovca();
        }
    }
    //****************************************/
    class Program
    {
        static void Main(string[] args)
        {
            VodjaGrupe vg = new VodjaGrupe("Sreten Prokopic", 1999, true, "Jadar", "Surice");
            //Lovac lo = new Lovac("Sreten Prokopic", 1999);

            Oruzje o1 = new Oruzje("LO-1234", 13);
            Oruzje o2 = new Oruzje("LO-456", 16);
            Oruzje o3 = new Oruzje("LO-7894", 12);

            Trofej t1 = new Trofej("2019/2020", "DS", 105);
            Trofej t2 = new Trofej("2020/2021", "VU", 600);

            vg.DodajOruzje(o1);
            vg.DodajOruzje(o2);
            vg.DodajOruzje(o3);

            vg.DodajTrofej(t1);
            vg.DodajTrofej(t2);

            vg.IspisVodjaGrupe();
            Console.WriteLine("*************************************");
            vg.BrojOruzja();
            vg.BrojTrofeja();

        }
    }
}


